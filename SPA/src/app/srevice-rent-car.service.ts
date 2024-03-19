import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Cars } from './Cars';

@Injectable({
  providedIn: 'root'
})
export class SreviceRentCarService {
  httpClient = inject(HttpClient);
  constructor() { }

  getAll(){
    return this.httpClient.get<Cars[]>('https://localhost:7280/api/Cars')
  };

  getByID(id: number){
    return this.httpClient.get<Cars>(`https://localhost:7280/api/Cars/${id}`);
  };

  edit(item:Cars){
    return this.httpClient.put(`https://localhost:7280/api/Cars/Update`, item);
  };

  delete(id: number){
    return this.httpClient.delete(`https://localhost:7280/api/Cars/Delete/`+id);
  };

  create(item:Cars){
    return this.httpClient.post<Cars>(`https://localhost:7280/api/Cars/Create`, item);
  };
}
