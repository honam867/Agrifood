import { DashBoardTotalCow } from './../../models/dashboardTotalCow';
import { DashBoardService } from './../../dashboard.service';
import { Component, OnInit } from '@angular/core';
import { Chart } from "node_modules/chart.js";
import ChartDataLabels from 'chartjs-plugin-datalabels';

@Component({
  selector: 'app-dashboard-list',
  templateUrl: './dashboard-list.component.html',
  styleUrls: ['./dashboard-list.component.scss']
})
export class DashboardListComponent implements OnInit {
  myChart: any;
  totalCow: DashBoardTotalCow = new DashBoardTotalCow();
  dataTotalCow: any;
  sumCow: any;

  constructor(
    public dashBoardService: DashBoardService
  ) { }

  ngOnInit(): void {
    this.fetchTotalCow();
  }
  fetchTotalCow() {
    this.dashBoardService.getTotalCow().subscribe(
      res => {
        this.totalCow = res;
        this.dataTotalCow = Object.values(this.totalCow[0]);
        this.sumCow = this.dataTotalCow.shift();
        this.showChart(this.dataTotalCow);
      });
  }

  showChart(dataTotalCow: any) {
    console.log(dataTotalCow)
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
      plugins: [ChartDataLabels],
      options: {
        title: {
          display: true,
          text: `Thống kê tổng số bò theo loại`,
          position: 'top',
          color: "#000000"
        },
        legend: {
          position: 'bottom',
        },
        scales: {
          y: {
            beginAtZero: true
          }
        },
        plugins: {
          datalabels: {
            formatter: (value) => {
              if (value === 0) return value = '';
              let sum = 0;
              // let dataArr = ctx.chart.data.datasets[0].data;
              this.dataTotalCow.map(data => {
                sum += data;
              });
              let percentage = (value * 100 / sum).toFixed(2) + "%";
              return percentage;
            },
            color: '#fff',
          }
        }
      }
    });
  }


}
