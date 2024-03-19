import { Component, inject, input } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {MatExpansionModule} from '@angular/material/expansion';
import { Cars } from '../../Cars';
import {MatButtonModule} from '@angular/material/button'
// import { ConsoleReporter } from 'jasmine';
//import { identifierName } from '@angular/compiler';
import { SreviceRentCarService } from '../../srevice-rent-car.service';
import { Router } from '@angular/router';


// export interface PeriodicElement {
//   name: string;
//   position: number;
//   weight: number;
//   symbol: string;
// }

// const ELEMENT_DATA: PeriodicElement[] = [
//   {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
//   {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
//   {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
//   {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
//   {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
//   {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
//   {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
//   {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
//   {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
//   {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
// ];


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatExpansionModule, MatButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})





export class HomeComponent {
  itemList:Cars[]=[];
  carService= inject(SreviceRentCarService)
  router = inject(Router)

  
  ngOnInit(){
    this.carService.getAll().subscribe((result)=>{
      this.itemList = result
    })
  }
  
  displayedColumns: string[] = ['id', 'brand', 'year', 'actions'];
  panelOpenState = false;

  tableVisible = false;

  toggleTableVisibility(): void {
    this.tableVisible = !this.tableVisible;
  }

  


 

  c(){
    console.log("create");
    this.router.navigateByUrl("/create");
  };
  e(id:number){
    console.log("edit", id);
    this.router.navigateByUrl("/edit/"+ id);
  };
  dt(id:number){
    console.log("details", id);
    this.router.navigateByUrl("/details/"+ id);
  };
  dl(id:number){
    console.log("delete", id);
    this.router.navigateByUrl("/delete/"+ id);
  };

}
