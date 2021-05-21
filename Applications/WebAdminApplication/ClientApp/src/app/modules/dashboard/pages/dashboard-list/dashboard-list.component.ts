import { DashBoardTotalCow } from './../../models/dashboardTotalCow';
import { DashBoardService } from './../../dashboard.service';
import { Component, OnInit } from '@angular/core';
import {Chart} from "node_modules/chart.js";

@Component({
  selector: 'app-dashboard-list',
  templateUrl: './dashboard-list.component.html',
  styleUrls: ['./dashboard-list.component.scss']
})
export class DashboardListComponent implements OnInit {
  myChart: Chart;
  totalCow: DashBoardTotalCow = new DashBoardTotalCow();
  dataTotalCow: any;



  constructor(
    public dashBoardService: DashBoardService
  ) { }

  ngOnInit(): void {
    this.fetchTotalCow();
    setTimeout(() => {
      this.showChart();
    }, 500);
  }

  fetchTotalCow() {
    this.dashBoardService.getTotalCow().subscribe(
      res => {
        this.totalCow = res;
        this.dataTotalCow = Object.values(this.totalCow[0]);
        this.dataTotalCow.shift();
      });
  }

  showChart(){
    this.myChart = new Chart("myChart", {
      type: 'pie',
      data: {
        labels: [
          'Sinh sản',
          'Bò thịt',
          'Bê'
        ],
        datasets: [{
          label: 'Tổng bò',
          data: this.dataTotalCow,
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)'
          ],
          hoverOffset: 4
        }]
      },
      options: {
          scales: {
              y: {
                  beginAtZero: true
              }
          },
          plugins: {

          }
      }
  });
  }


}
