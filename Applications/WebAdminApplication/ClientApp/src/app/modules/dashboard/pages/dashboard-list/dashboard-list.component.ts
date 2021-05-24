import { DashBoardTotalCow } from './../../models/dashboardTotalCow';
import { DashBoardService } from './../../dashboard.service';
import { Component, OnInit } from '@angular/core';
import { Chart } from "node_modules/chart.js";
import ChartDataLabels from 'chartjs-plugin-datalabels';
import { parseString } from 'xml2js';

@Component({
  selector: 'app-dashboard-list',
  templateUrl: './dashboard-list.component.html',
  styleUrls: ['./dashboard-list.component.scss']
})
export class DashboardListComponent implements OnInit {
  totalCowChart: any;
  totalOrderChart: any;
  totalCow: DashBoardTotalCow = new DashBoardTotalCow();
  dataTotalCow: any;
  sumCow: any;
  totalOrderlabels : string[] = [];
  totalOrderdata: number[] =[];
  totalOrderrandomColor: string[] =[];
  endDate = new Date();
  startDate = new Date();
  constructor(
    public dashBoardService: DashBoardService
  ) { }

  ngOnInit(): void {
    this.startDate.setFullYear(this.endDate.getFullYear()-1);
    this.fetchTotalCow();
    this.fetchTotalOrder();
  }

  fetchTotalOrder() {
    this.dashBoardService.getTotalOrderFoodBytime(this.formatDate(this.startDate),this.formatDate(this.endDate)).subscribe(
      res => {
        for (let index = 0; index < res.length; index++) {
          this.totalOrderlabels.push(res[index].foodName);
          this.totalOrderdata.push(res[index].quantity);
          let r = Math.floor(Math.random()*16777215).toString(16);
          this.totalOrderrandomColor.push('#'+r);
        }
        this.showTotalOrderChart();
      });
  }

  create(){
    this.totalOrderlabels.splice(0,this.totalOrderlabels.length);
    this.totalOrderdata.splice(0,this.totalOrderdata.length);
    this.totalOrderrandomColor.splice(0,this.totalOrderrandomColor.length);
    this.fetchTotalOrder();
  }

  formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [year, month, day].join('');
}

  fetchTotalCow() {
    this.dashBoardService.getTotalCow().subscribe(
      res => {
        this.totalCow = res;
        this.dataTotalCow = Object.values(this.totalCow[0]);
        this.sumCow = this.dataTotalCow.shift();
        this.showTotalCowChart(this.dataTotalCow);
      });
  }

    showTotalOrderChart() {
    this.totalCowChart = new Chart("totalOrderChart", {
      type: 'bar',
      data: {
        labels: this.totalOrderlabels,
        datasets:[{
          label:'',
          backgroundColor: this.totalOrderrandomColor,
          data: this.totalOrderdata}
         ]
      },
      options: {
        responsive: true,
        legend:{
          display: false
        },
        title: {
          display: true,
          text: `Thống kê tổng số thức ăn đã xuất theo hóa đơn`,
          position: 'top',
          color: "#000000"
        },
        tooltips: {
          callbacks: {
            label: (item) => `${item.yLabel} Kg`,
          },
        },
      },
    });
  }

  showTotalCowChart(dataTotalCow: any) {
    this.totalCowChart = new Chart("totalCowChart", {
      type: 'pie',
      data: {
        labels: [
          'Sinh sản',
          'Bò thịt',
          'Bê'
        ],
        datasets: [{
          label: 'Tổng bò',
          data: dataTotalCow,
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
