import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { ToastData, ToastOptions, ToastyService } from 'ng2-toasty';
import { TargetSettingService } from '../../../service/bdm/targetsetting.service';

@Component({
  selector: 'app-targetsetting',
  templateUrl: './targetsetting.component.html',
  styleUrls: ['./targetsetting.component.css',
    '../../../../../node_modules/ng2-toasty/style-bootstrap.css',
    '../../../../../node_modules/ng2-toasty/style-default.css',
    '../../../../../node_modules/ng2-toasty/style-material.css'],
  encapsulation: ViewEncapsulation.None
})
export class TargetsettingComponent implements OnInit {

  constructor(private toastr: ToastyService, private targetsettingService: TargetSettingService) { }
  month: Month[] = [
    { value: 1, viewValue: 'Jan' },
    { value: 2, viewValue: 'Feb' },
    { value: 3, viewValue: 'Mar' },
    { value: 4, viewValue: 'Aprl' },
    { value: 5, viewValue: 'May' },
    { value: 6, viewValue: 'Jun' },
    { value: 7, viewValue: 'July' },
    { value: 8, viewValue: 'Aug' },
    { value: 9, viewValue: 'sep' },
    { value: 10, viewValue: 'Oct' },
    { value: 11, viewValue: 'Nov' },
    { value: 12, viewValue: 'Dec' },
  ];

  year: Year[] = [{ Value: 2015, Year: 2015 }, { Value: 2016, Year: 2016 }, { Value: 2017, Year: 2017 },
  { Value: 2018, Year: 2018 }, { Value: 2019, Year: 2019 }, { Value: 2020, Year: 2020 }, { Value: 2021, Year: 2021 },
  { Value: 2022, Year: 2022 }, { Value: 2023, Year: 2023 }, { Value: 2024, Year: 2024 }, { Value: 2025, Year: 2025 },
  { Value: 2026, Year: 2026 }, { Value: 2027, Year: 2027 }, { Value: 2028, Year: 2028 }, { Value: 2029, Year: 2029 },
  { Value: 2030, Year: 2030 }, { Value: 2031, Year: 2031 }, { Value: 2032, Year: 2032 }, { Value: 2033, Year: 2033 },
  { Value: 2034, Year: 2034 }, { Value: 2035, Year: 2035 }, { Value: 2036, Year: 2036 }, { Value: 2037, Year: 2037 },
  { Value: 2038, Year: 2038 }, { Value: 2039, Year: 2039 }, { Value: 2040, Year: 2040 }, { Value: 2041, Year: 2041 },
  { Value: 2042, Year: 2042 }, { Value: 2043, Year: 2043 }, { Value: 2044, Year: 2044 }, { Value: 2045, Year: 2045 },
  { Value: 2046, Year: 2046 }, { Value: 2047, Year: 2047 }, { Value: 2048, Year: 2048 }, { Value: 2049, Year: 2049 },
  { Value: 2050, Year: 2050 }];
  EmployeeTargetList: any = [];
  TargetEmployeeList: any = [];
  model: any = {};
  selectedAll: boolean = false;
  position = 'top-right';
  theme = 'bootstrap';
  type = 'default';
  ngOnInit() {
    var obj = {
      EmployeeId: 1001
    }
    this.targetsettingService.getAllEmployeeByReportTo(obj).subscribe(res => {
      this.EmployeeTargetList = res.result;
      for (var i in this.EmployeeTargetList) {
        this.EmployeeTargetList[i].isSelected = false
      }
      var obj = {
        ActionBy: 1001
      }
      this.targetsettingService.getAllTargets(obj).subscribe(res => {
        this.TargetEmployeeList = res.result;
      })
    })
  }

  SelectMonth(model) {
    var getByMonth = {
      Month: model.selectedMonth,
      Year: model.selectedYear,
      ReportTo: 1001
    }
    this.targetsettingService.getDetailByMonth(getByMonth).subscribe(res => {
      for (var t in this.EmployeeTargetList) {
        for (var target in res.result) {
          if (this.EmployeeTargetList[t].EmployeeId == res.result[target].EmployeeId) {
            this.EmployeeTargetList[t].TargetAmount = res.result[target].TargetAmount;
          }
        }
      }
    })
  }

  selectChec() {
    if (this.selectedAll) {
      this.selectedAll = false;
    } else {
      this.selectedAll = true;
    }
    for (var i in this.EmployeeTargetList) {
      this.EmployeeTargetList[i].isSelected = this.selectedAll;
    }
  };

  checkbox: boolean = false;
  ischecked(check) {
    if (check) {
      this.checkbox = true;
    }
  }

  TargetEmployee() {
    var List = [];
    for (var i in this.EmployeeTargetList) {
      if (this.EmployeeTargetList[i].isSelected) {
        var temp = {
          EmployeeId: this.EmployeeTargetList[i].EmployeeId,
          TargetAmount: this.EmployeeTargetList[i].TargetAmount,
        }
        List.push(temp);
      }
    }
    var ObjlistTarget = {
      listTarget: List,
      Month: this.model.selectedMonth,
      Year: this.model.selectedYear,
      CreatedBy: 1001,
      ReportTo: 100
    }
    this.targetsettingService.AddEmployeeTarget(ObjlistTarget).subscribe((res: any) => {
      // alert("Insert sucessful")
      debugger;
      this.toastr.success("Added successfully")
      this.ngOnInit();
    });
  }

  removeTarget(row) {
    var objDeleteTarget = {
      Id: row.Id
    }

    if (window.confirm("Sure you want to delete this Employee Target")) {
      this.targetsettingService.RemoveEmployeeTarget(objDeleteTarget).subscribe((res: any) => {
        // alert("Insert sucessful")
        debugger;
        this.toastr.success("Deleted successfully")
        this.ngOnInit();
      });
    }

  }


}

export interface Month {
  value: number;
  viewValue: string;
}
export interface Year {
  Value: number;
  Year: number;
}
