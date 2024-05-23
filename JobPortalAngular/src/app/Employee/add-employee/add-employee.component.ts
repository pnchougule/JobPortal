import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Employee } from '../../Services/Employee';
import { EmployeeService } from '../../Services/employee.service';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css'
})
export class AddEmployeeComponent {
  emp:Employee=new Employee();
  
  
  constructor(private empService:EmployeeService, private router: Router) {}

  backToEmployeeList(){
    this.router.navigate(['/Employee']);
  }

  saveEmployee(){
    console.log(this.emp);
    this.empService.AddEmployee(this.emp).subscribe(data => {
      console.log(data);
      this.empService.GetAllEmployees();
    });
    this.router.navigate(['/Employee']);
   
  }
}
