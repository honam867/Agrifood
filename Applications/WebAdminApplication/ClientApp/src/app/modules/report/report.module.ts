import { MaterialModule } from './../../shared/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReportRoutingModule } from './report-routing.module';
import { ReportComponent } from './report.component';
import { DxReportViewerModule } from 'devexpress-reporting-angular';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [ReportComponent],
  imports: [
    CommonModule,
    ReportRoutingModule,
    DxReportViewerModule,
    SharedModule
  ],
})
export class ReportModule { }
