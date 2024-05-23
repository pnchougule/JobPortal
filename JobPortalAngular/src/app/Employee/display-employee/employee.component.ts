import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Employee } from '../../Services/Employee';
import { EmployeeService } from '../../Services/employee.service';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterLink],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit {
  employees!: Employee[];

  constructor(private empService: EmployeeService, private router: Router) {}

  ngOnInit(): void {
    this.getEmployees();
  }

   getEmployees(): void {
    this.empService.GetAllEmployees().subscribe(data => {
      this.employees = data;
    });
  }

  deleteEmployee(empId: number): void {
    this.empService.DeleteEmployee(empId).subscribe(data => {
      console.log(data);
       this.getEmployees();
    });
  }
}