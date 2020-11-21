import { Component, OnInit } from '@angular/core';
import { LoaderService } from 'src/app/shared/services/loader.service';

@Component({
  selector: 'app-progress-sprinner-loader',
  templateUrl: './progress-sprinner-loader.component.html',
  styleUrls: ['./progress-sprinner-loader.component.scss']
})
export class ProgressSprinnerLoaderComponent implements OnInit {

  constructor(public loaderService: LoaderService) { }

  ngOnInit() {
  }

}
