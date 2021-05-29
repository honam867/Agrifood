import { Cow } from './../../../cow/models/cow';
import { StatusForm } from './../../../../shared/enum/status-form';
import { DashBoardService } from './../../../dashboard/dashboard.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Component, OnInit, Inject } from '@angular/core';
import { Chart } from "node_modules/chart.js";


@Component({
  selector: 'app-cow-dashboard',
  templateUrl: './cow-dashboard.component.html',
  styleUrls: ['./cow-dashboard.component.scss']
})
export class CowDashboardComponent implements OnInit {
  cow: Cow = new Cow();
  endDateMilkingSlip = new Date();
  startDateMilkingSlip = new Date();
  totalMilkingSlipChart: any;
  totalMilkingSlipLabels: string[] = [];
  totalMilkingSLipData: number[] = [];
  dateRangeMilkingSlip: any;
  constructor(
    public dialogRef: MatDialogRef<CowDashboardComponent>,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dashBoardService: DashBoardService
  ) { }

  ngOnInit(): void {
    this.cow = this.data.cow;
    this.startDateMilkingSlip.setMonth(this.endDateMilkingSlip.getMonth() - 1);
    this.startDateMilkingSlip.setDate(this.endDateMilkingSlip.getDate() + 1);
    this.fetchCowDashboardData();
  }

  selectRangeMilkingSlip() {
    this.totalMilkingSlipLabels.splice(0, this.totalMilkingSlipLabels.length);
    this.totalMilkingSLipData.splice(0, this.totalMilkingSLipData.length);
    this.startDateMilkingSlip = this.dateRangeMilkingSlip.begin;
    this.endDateMilkingSlip = this.dateRangeMilkingSlip.end;
    this.fetchCowDashboardData();
    // this.totalMilkingSlipChart.update();
  }

  fetchCowDashboardData(){
    this.dashBoardService.getMilkingSlipByCowId(this.formatDate(this.startDateMilkingSlip, 'a'), this.formatDate(this.endDateMilkingSlip, 'a'), this.cow.id).subscribe(
      res => {
        for (let index = 0; index < res.length; index++) {
          this.totalMilkingSlipLabels.push(this.formatDate(res[index].day, 'b'));
          this.totalMilkingSLipData.push(res[index].quantity);
        }
        console.log(this.totalMilkingSlipLabels);
        console.log(this.totalMilkingSLipData);
        this.showTotalMilkingSlipChart();
      });
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
        scales: {
          y: {
            beginAtZero: true
          }
        },
        title: {
          display: true,
          text: `Thống kê tổng số lượng sữa được vắt của bò`,
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

  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW
    });
  }

}
