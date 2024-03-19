import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatChipsModule } from '@angular/material/chips';
import { SreviceRentCarService } from '../../srevice-rent-car.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [MatFormFieldModule, FormsModule, MatSelectModule, MatInputModule, MatButtonModule, MatChipsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})

export class CreateComponent {
  carsService = inject(SreviceRentCarService);
  router = inject(Router);
  cate: any;
  cID: number = 0;

  createCar: any ={
    brand: "",
    model: "",
    year: "",
    customerId: 0
  };


  ngOnInit(){
    this.carsService.getAll().subscribe((result)=> {
      this.cate = result
    });
  };

  create(){
    this.createCar.customerId = this.cID
    this.carsService.create(this.createCar).subscribe(result=> {
      alert("Saved!")
      this.router.navigateByUrl("home")
    });
  };

  back(){
    this.router.navigateByUrl("home")
  }
}
