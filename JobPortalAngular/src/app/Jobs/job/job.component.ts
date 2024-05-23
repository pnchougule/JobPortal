import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Job } from '../../Services/Job';
import { JobService } from '../../Services/job.service';

@Component({
  selector: 'app-job',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterLink],
  templateUrl: './job.component.html',
  styleUrl: './job.component.css'
})
export class JobComponent implements OnInit {
  jobs!: Job[];

  constructor(private jobService: JobService, private router: Router) {}

  ngOnInit(): void {
    this.getJds();
  }

  getJds(): void {
    this.jobService.GetAllJds().subscribe(data => {
      this.jobs = data;
    });
  }

  deleteJob(id: number): void {
    this.jobService.DeleteJd(id).subscribe(data => {
      console.log(data);
       this.getJds();
    });
  }

  updateJd(id: number) {
    console.log("Id to update: ",id);
    this.router.navigate(['/editJob', id]);
  }

  addAdmin(){
    this.router.navigate(['/addJob']);
  }

}
