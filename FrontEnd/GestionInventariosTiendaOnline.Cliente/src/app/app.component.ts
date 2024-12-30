import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Cliente';
  isUserLoggedIn = true;
  username = '';

  ngOnInit() {
    const user = localStorage.getItem('username'); // Recupera el nombre de usuario sin parsear
    if (user) {
      this.isUserLoggedIn = true;
      this.username = user; // Asigna el nombre de usuario directamente
    }
  }
}