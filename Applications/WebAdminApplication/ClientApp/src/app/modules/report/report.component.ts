import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: [
    './report.component.scss']
})
export class ReportComponent implements OnInit {
  reportUrl = '';
  hostUrl = environment.host;
  invokeAction = 'DXXRDV';
  constructor(
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params.reportname) {
        this.reportUrl = params.reportname;
      }
    });
  }

  exit() {
    this.location.back();
  }

}
