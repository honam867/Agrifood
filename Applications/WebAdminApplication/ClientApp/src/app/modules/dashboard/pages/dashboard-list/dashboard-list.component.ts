import { DashBoardTotalCow } from './../../models/dashboardTotalCow';
import { DashBoardService } from './../../dashboard.service';
import { Component, OnInit } from '@angular/core';
import { Chart } from "node_modules/chart.js";
import ChartDataLabels from 'chartjs-plugin-datalabels';
import { Farmer } from 'src/app/modules/farmer/models/farmer';
import { MatDatepicker } from '@angular/material/datepicker';

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
  totalOrderLabels: string[] = [];
  totalOrderData: number[] = [];
  totalOrderRandomColor: string[] = [];
  dateRangeTotalOrder: any;
  endDate = new Date();
  startDate = new Date();
  totalMilkingSlipChart: any;
  totalMilkingSlipLabels: string[] = [];
  totalMilkingSLipData: number[] = [];
  dateRangeMilkingSlip: any;
  endDateMilkingSlip = new Date();
  startDateMilkingSlip = new Date();
  totalMilkCouponChart: any;
  totalMilkCouponLabels: string[] = [];
  totalMilkCouponData: number[] = [];
  dateRangeMilkCoupon: any;
  startDateMilkCoupon = new Date();
  endDateMilkCoupon = new Date();
  yearUsing: number;
  date = new Date();
  yearUsingChart: any;
  yearUsingLabels: string[] = [];
  yearUsingData: number[] = [];
  isMini: boolean;
  canvasHeight = 130;
  constructor(
    public dashBoardService: DashBoardService
  ) { }

  ngOnInit(): void {
    // this.isActive = true;
    this.isMini = false;
    this.startDate.setFullYear(this.endDate.getFullYear() - 1);
    this.startDateMilkingSlip.setMonth(this.endDateMilkingSlip.getMonth() - 1);
    this.startDateMilkingSlip.setDate(this.endDateMilkingSlip.getDate() + 1);
    this.startDateMilkCoupon.setMonth(this.endDateMilkCoupon.getMonth() - 1);
    this.startDateMilkCoupon.setDate(this.endDateMilkCoupon.getDate() + 1);
    // this.dateRangeMilkCoupon.begin = this.startDateMilkCoupon;
    // this.dateRangeMilkCoupon.end = this.endDateMilkCoupon

    // this.dateRange.begin = this.startDate;
    // this.dateRange.end = this.endDate;
    this.fetchTotalCow();
    this.fetchTotalOrder();
    this.fetchTotalMilkingSlip();
    this.fetchTotalMilkCoupon();
    this.fetchUsingDataByYear(this.date.getFullYear());
  }

  submitYearUsing() {
    this.fetchUsingDataByYear(this.yearUsing);
  }

  yearHandler(data, datepicker: MatDatepicker<Date>) {
    this.yearUsing = data._i.year;
    datepicker.close();
  }

  fetchUsingDataByYear(year) {
    this.dashBoardService.getUsingDataByYear(year).subscribe(
      res => {
        this.yearUsingLabels = res.map(item => 'Tháng ' + item.month);
        this.yearUsingData = res.map(item => item.dem);
        this.showYearUsingData();
      });
  }

  fetchTotalMilkingSlip() {
    this.dashBoardService.getMilkingSlip(this.formatDate(this.startDateMilkingSlip, 'a'), this.formatDate(this.endDateMilkingSlip, 'a')).subscribe(
      res => {
        for (let index = 0; index < res.length; index++) {
          this.totalMilkingSlipLabels.push(this.formatDate(res[index].day, 'b'));
          this.totalMilkingSLipData.push(res[index].quantity);
        }
        this.showTotalMilkingSlipChart();
      });
  }

  fetchTotalMilkCoupon() {
    this.dashBoardService.getMilkCoupon(this.formatDate(this.startDateMilkCoupon, 'a'), this.formatDate(this.endDateMilkCoupon, 'a')).subscribe(
      res => {
        for (let index = 0; index < res.length; index++) {
          this.totalMilkCouponLabels.push(this.formatDate(res[index].day, 'b'));
          this.totalMilkCouponData.push(res[index].quantity);
        }
        this.showTotalMilkCoupon();
      });
  }


  fetchTotalOrder() {
    this.dashBoardService.getTotalOrderFoodBytime(this.formatDate(this.startDate, 'a'), this.formatDate(this.endDate, 'a')).subscribe(
      res => {
        for (let index = 0; index < res.length; index++) {
          this.totalOrderLabels.push(res[index].foodName);
          this.totalOrderData.push(res[index].quantity);
          let r = Math.floor(Math.random() * 16777215).toString(16);
          this.totalOrderRandomColor.push('#' + r);
        }
        this.showTotalOrderChart();
      });
  }

  selectRangeMilkingSlip() {
    this.totalMilkingSlipLabels.splice(0, this.totalMilkingSlipLabels.length);
    this.totalMilkingSLipData.splice(0, this.totalMilkingSLipData.length);
    this.startDateMilkingSlip = this.dateRangeMilkingSlip.begin;
    this.endDateMilkingSlip = this.dateRangeMilkingSlip.end;
    this.fetchTotalMilkingSlip();
    // this.totalMilkingSlipChart.update();
  }

  selectRangeMilkCoupon() {
    this.totalMilkCouponLabels.splice(0, this.totalMilkCouponLabels.length);
    this.totalMilkCouponData.splice(0, this.totalMilkCouponData.length);
    this.startDateMilkCoupon = this.dateRangeMilkCoupon.begin;
    this.endDateMilkCoupon = this.dateRangeMilkCoupon.end;
    this.fetchTotalMilkCoupon();
    // this.totalMilkingSlipChart.update();
  }

  selectRangeTotalOrder() {
    this.totalOrderLabels.splice(0, this.totalOrderLabels.length);
    this.totalOrderData.splice(0, this.totalOrderData.length);
    this.totalOrderRandomColor.splice(0, this.totalOrderRandomColor.length);
    this.startDate = this.dateRangeTotalOrder.begin;
    this.endDate = this.dateRangeTotalOrder.end;
    this.fetchTotalOrder();
  }

  formatDate(date, functionName) {
    var d = new Date(date),
      month = '' + (d.getMonth() + 1),
      day = '' + d.getDate(),
      year = d.getFullYear();

    if (month.length < 2)
      month = '0' + month;
    if (day.length < 2)
      day = '0' + day;
    if (functionName === 'a') {
      return [year, month, day].join('');
    } else if (functionName === 'b') {
      return [day, month].join('/');
    }

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
    this.totalOrderChart = new Chart("totalOrderChart", {
      type: 'bar',
      data: {
        labels: this.totalOrderLabels,
        datasets: [{
          label: '',
          backgroundColor: this.totalOrderRandomColor,
          data: this.totalOrderData
        }
        ]
      },
      options: {
        responsive: true,
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero: true
            }
          }]
        },
        legend: {
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

  showTotalMilkingSlipChart() {
    this.totalMilkingSlipChart = new Chart("totalMilkingSlipChart", {
      type: 'line',
      data: {
        labels: this.totalMilkingSlipLabels,
        datasets: [{
          label: '',
          borderColor: 'rgb(14, 107, 104)',
          data: this.totalMilkingSLipData,
          tension: 0
        }
        ]
      },
      options: {
        responsive: true,
        legend: {
          display: false
        },
        title: {
          display: true,
          text: `Thống kê tổng số lượng sữa được vắt bởi nông dân`,
          position: 'top',
          color: "#000000"
        },
        tooltips: {
          displayColors: false,
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

  showTotalMilkCoupon() {
    this.totalMilkCouponChart = new Chart("totalMilkCouponChart", {
      type: 'line',
      data: {
        labels: this.totalMilkCouponLabels,
        datasets: [{
          label: '',
          borderColor: 'rgb(14, 107, 104)',
          data: this.totalMilkCouponData,
          tension: 0,
        }
        ]
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true
          }
        },
        legend: {
          display: false
        },
        title: {
          display: true,
          text: `Thống kê tổng số lượng sữa thu mua`,
          position: 'top',
          color: "#000000"
        },
        tooltips: {
          displayColors: false,
          callbacks: {
            label: (item) => `${item.yLabel} Kg`,
          },
        },
      },
    });
  }

  showYearUsingData() {
    this.yearUsingChart = new Chart("yearUsingChart", {
      type: 'line',
      data: {
        labels: this.yearUsingLabels,
        datasets: [{
          label: '',
          borderColor: 'rgb(14, 107, 104)',
          data: this.yearUsingData,
          tension: 0,
        }
        ]
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true
          }
        },
        legend: {
          display: false
        },
        title: {
          display: true,
          text: `Thống kê tổng lưu lượng sử dụng của nông dân`,
          position: 'top',
          color: "#000000"
        },
        tooltips: {
          displayColors: false,
          callbacks: {
            label: (item) => `${item.yLabel} lần`,
          },
        },
      },
    });
  }


}
