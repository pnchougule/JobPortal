import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router'; 
import { AppComponent } from './app.component';
import { AdminComponent } from './Admin/display-admin/admin.component';
import { EmployeeComponent } from './Employee/display-employee/employee.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { EditAdminComponent } from './Admin/edit-admin/edit-admin.component';
import { AddAdminComponent } from './Admin/add-admin/add-admin.component';
import { EditEmployeeComponent } from './Employee/edit-employee/edit-employee.component';
import { AddEmployeeComponent } from './Employee/add-employee/add-employee.component';
import { AddJobComponent } from './Jobs/add-job/add-job.component';
import { EditJobComponent } from './Jobs/edit-job/edit-job.component';
import { JobComponent } from './Jobs/job/job.component';

export const routes: Routes = [
  { path: 'Admin', component: AdminComponent },
  { path: 'Employee', component: EmployeeComponent },
  { path: 'Login', component: LoginComponent },
  { path: 'Register', component: RegisterComponent },
  { path: 'editAdmin/:id', component: EditAdminComponent },
  { path: 'addAdmin', component: AddAdminComponent },
  { path: 'editEmployee/:id', component: EditEmployeeComponent },
  { path: 'addEmployee', component: AddEmployeeComponent },
  { path: 'addJob', component: AddJobComponent },
  { path: 'editJob/:id', component: EditJobComponent },
  { path: 'Job', component: JobComponent },
  { path: '', redirectTo: '/Login', pathMatch: 'full' }, // Default route
  { path: '**', redirectTo: '/Admin', pathMatch: 'full' } // Wildcard route for a 404 page
];


