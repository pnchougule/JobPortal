import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Job Portal';
  constructor(private router: Router ){}

  admin(): void {
    this.router.navigate(['/Admin']);
  }
  employee(): void{
    this.router.navigate(['/Employee']);
  }
  job():void{
    this.router.navigate(['/Job']);
  }
}
