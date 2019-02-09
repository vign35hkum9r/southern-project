import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { ToastData, ToastOptions, ToastyService } from 'ng2-toasty';
import { TargetSettingService } from '../../../service/bdm/targetsetting.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css',
  '../../../../../node_modules/ng2-toasty/style-bootstrap.css',
  '../../../../../node_modules/ng2-toasty/style-default.css',
  '../../../../../node_modules/ng2-toasty/style-material.css'],
encapsulation: ViewEncapsulation.None
})
export class HomeComponent implements OnInit {

  constructor() { }
  position = 'top-right';
  theme = 'bootstrap';
  type = 'default';

  ngOnInit() {
  }

}
