import { Component, inject } from '@angular/core';
import { Cars } from '../../Cars';
import { SreviceRentCarService } from '../../srevice-rent-car.service';
import { ActivatedRoute } from '@angular/router';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [MatCardModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  detailsCars:Cars={
    id: 0,
    brand: "",
    model: "",
    year: 0,
    customerId: 0,
    customer: {
      id: 0,
      customer_name: "",
      customer_email: '',
      customer_phone: ''
    },
    color: ''
  }

  serviceCars= inject(SreviceRentCarService)

  activateRoute = inject(ActivatedRoute)

  ngOnInit(){
    this.serviceCars.getByID(this.activateRoute.snapshot.params["id"]).subscribe((result)=> {
      this.detailsCars = result
    });
  }
}
