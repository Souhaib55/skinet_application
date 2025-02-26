import { Component, inject, OnInit } from '@angular/core';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Product } from './shared/models/product';
import { ApiResponse } from './shared/models/pagination'; // Adjust the import path based on where you defined ApiResponse

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HeaderComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  baseUrl = 'https://localhost:5001/api/';
  private http = inject(HttpClient);
  title = 'Skinet';
  products: Product[] = [];

  trackById(index: number, item: Product) {
    return item.id;
  }

  ngOnInit(): void { 
    this.http.get<ApiResponse<Product>>(this.baseUrl + 'products').subscribe({ 
      next: response => {
        this.products = response.value.data;
      },  
      error: error => console.log(error), 
      complete: () => console.log('complete') 
    }); 
  }
}