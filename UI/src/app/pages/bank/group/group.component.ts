import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { ToastData, ToastOptions, ToastyService } from 'ng2-toasty';
import { GroupService } from '../../../service/Account/group.service';
import { sortedIndex } from "lodash";
export interface Transaction {
    item: string;
    cost: number;
}

@Component({
    selector: 'app-group',
    templateUrl: './group.component.html',
    styleUrls: ['./group.component.scss',
        '../../../../../node_modules/ng2-toasty/style-bootstrap.css',
        '../../../../../node_modules/ng2-toasty/style-default.css',
        '../../../../../node_modules/ng2-toasty/style-material.css'],
    encapsulation: ViewEncapsulation.None
})


export class GroupComponent implements OnInit {
    model: any = [];
    tempList: any = [];
    GroupList = [];
    isFormOpen: boolean = false;
    isEditing: boolean = false;
    position = 'top-right';
    theme = 'bootstrap';
    type = 'material';
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    displayedColumns: string[] = ['item', 'cost'];
    GroupComponent: Transaction[] = [
        { item: 'Beach ball', cost: 4 },
        { item: 'Towel', cost: 5 },
        { item: 'Frisbee', cost: 2 },
        { item: 'Sunscreen', cost: 4 },
        { item: 'Cooler', cost: 25 },
        { item: 'Swim suit', cost: 15 },
    ];

    /** Gets the total cost of all transactions. */
    getTotalCost() {
        return this.GroupComponent.map(t => t.cost).reduce((acc, value) => acc + value, 0);
    }

    constructor(private toastr: ToastyService, private groupService: GroupService) { }

    ngOnInit() {
        this.groupService.getallGroup().subscribe(res => {
            this.GroupList = res;
        })
    }
    SaveGroup(model) {
        debugger;
        var obj: any = {
            Descrip_Group: model.Descrip_Group,
            Parent_Group: (model.SelectedDescrip_Group != undefined) ? model.SelectedDescrip_Group.GroupId : 0,
        }
        if (!this.isEditing) {
            obj.CreatedBy = 1004
            this.groupService.createGroup(obj).subscribe((res: any) => {
                this.toastr.success(res.Message);
                this.model = {};
                this.ngOnInit();
            });
        }
        else {
            obj.GroupId = this.model.GroupId;
            obj.ModifiedBy = 1004
            this.groupService.updateGroup(obj).subscribe((res: any) => {
                this.toastr.success(res.Message);
                this.clear();
            });

        }
    }

    Edit(row) {
        debugger;

        this.isEditing = true;
        this.model = JSON.parse(JSON.stringify(row));
        this.model.Descrip_Group = row.Descrip_Group
        for (var i in this.GroupList) {
            if (this.GroupList[i].GroupId == row.Parent_Group) {
                this.model.SelectedDescrip_Group = JSON.parse(JSON.stringify(this.GroupList[i]));
            }
        }

        this.tempList = [];
        for (var i in this.GroupList) {
            if (this.GroupList[i].GroupId != row.GroupId) {
                this.tempList.push(this.GroupList[i]);
            }
        }
        this.GroupList = JSON.parse(JSON.stringify(this.tempList));
        this.isFormOpen = true;
    }

    clearSubgroup(model) {
        this.model.SelectedDescrip_Group = undefined;
    }

    create() {
        this.isFormOpen = true;
        this.isEditing = false;
        this.model = {};
    }
    clear() {
        this.model = {};
        this.isFormOpen = false;
        this.isEditing = false;
        this.ngOnInit();
    }


}
