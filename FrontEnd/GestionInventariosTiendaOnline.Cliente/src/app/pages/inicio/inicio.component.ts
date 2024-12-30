import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card'
import { MatTableModule } from '@angular/material/table'
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

import { ProductoService } from '../../services/producto.service';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Producto } from '../../interfaces/Producto';

@Component({
     selector: 'app-inicio',
     standalone: true,
     imports: [CommonModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatCardModule, MatTableModule, MatButtonModule, MatDialogModule, ReactiveFormsModule],
     templateUrl: './inicio.component.html',
     styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {
     public isAdminLoggedIn = false;
     private productoServicio = inject(ProductoService);
     private fb = inject(FormBuilder);
     public listaProducto: Producto[] = [];
     public displayedColumns: string[] = ['name', 'description', 'price', 'category', 'quantityInventory', 'actions'];

     public productoForm: FormGroup;

     ngOnInit(): void {
          const user = localStorage.getItem('username');
          const role = localStorage.getItem('rol');
          
          if (role == "Administrador") {
               this.isAdminLoggedIn = true;
          }
     }

     constructor(private dialog: MatDialog) {
          this.productoForm = this.fb.group({
               name: [''],
               description: [''],
               price: [''],
               category: [''],
               quantityInventory: ['']
          });



          this.cargarProductos();
     }
     

     cargarProductos() {
          this.productoServicio.lista().subscribe({
               next: (data) => {
                    this.listaProducto = data;
               },
               error: (err) => {
                    console.log(err.message);
               }
          });
     }

     crearProducto() {
          const nuevoProducto: Producto = this.productoForm.value;
          this.productoServicio.crearProducto(nuevoProducto).subscribe({
               next: () => {
                    this.cargarProductos();
               },
               error: (err) => {
                    alert(err.message);
               }
          });
     }

     eliminarProducto(product: Producto) {
          this.productoServicio.eliminarProducto(product).subscribe({
               next: () => {
                    this.cargarProductos();
               },
               error: (err) => {
                    this.cargarProductos();
                    alert(err.message);
               }
          });
     }
}
