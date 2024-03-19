import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {MatButtonModule} from '@angular/material/button';
import { Cars } from './Cars';
import { HomeComponent } from './components/home/home.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatButtonModule, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'CarRent';
  itemsList:Cars[] =
  [
    {
        id: 1,
        brand: "string",
        model: "string",
        year: 2020,
        color: "string",
        customerId: 12,
        customer:{
            id: 12,
            customer_name: "string",
            customer_email: "string",
            customer_phone: "string"}
    },
    {
        id: 1,
        brand: "string",
        model: "string",
        year: 2020,
        color: "string",
        customerId: 12,
        customer:{
            id: 12,
            customer_name: "string",
            customer_email: "string",
            customer_phone: "string"}
    },
    {
        id: 1,
        brand: "string",
        model: "string",
        year: 2020,
        color: "string",
        customerId: 12,
        customer:{
            id: 12,
            customer_name: "string",
            customer_email: "string",
            customer_phone: "string"}
    }

  ]
}
