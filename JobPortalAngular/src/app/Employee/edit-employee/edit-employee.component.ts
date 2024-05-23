import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from '../../Services/Employee'; 
import { EmployeeService } from '../../Services/employee.service'; 
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-employee',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
  emp: Employee = new Employee();
  id: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
      console.log(this.id);
      this.getEmployeeById(this.id);
    });
  }

  private getEmployeeById(employeeId: number): void {
    this.employeeService.GetEmployeeById(employeeId).subscribe(data => {
      console.log(data);
      this.emp = data;
    }, error => console.log(error));
  }

  backToEmployeeList(): void {
    this.router.navigate(['/Employee']);
  }

  updateEmployee(): void {
    this.employeeService.UpdateEmployee(this.emp).subscribe(data => {
      console.log(data);
      this.employeeService.GetAllEmployees();
    });
    this.router.navigate(['/Employee']);
  }
}
