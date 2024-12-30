import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../settings/appsettings';
import { ResponseProducto } from '../interfaces/ResponseProducto';
import { Observable } from 'rxjs';
import { Producto } from '../interfaces/Producto';

@Injectable({
     providedIn: 'root'
})
export class ProductoService {

     private http = inject(HttpClient);
     private baseUrl: string = appsettings.apiProductQueryUrl;
     constructor() { }

     lista() : Observable<any>{
          return  this.http.get<any>(`${this.baseUrl}products`)
     }

     crearProducto(producto: Producto): Observable<Producto> 
     { 
          return this.http.post<any>(`${appsettings.apiProductCreateUrl}createproducts`, producto);
     } 
     
     eliminarProducto(producto: Producto): Observable<Producto> 
     { 
          return this.http.post<any>(`${appsettings.apiProductCreateUrl}deleteproducts`, producto);
     } 
}