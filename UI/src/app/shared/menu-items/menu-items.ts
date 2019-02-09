import { Injectable } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { configuration } from '../../common/configuration/config';
import { HttpClient } from '@angular/common/http';

export interface SubMenuItems {
  MenuUrl: string;
  target?: boolean;
  MenuName: string;
  SubMenuItems?: SubMenuItems[];
}

export interface MainMenuItems {
  IsSelected: boolean;
  type : string;
  MenuAction: any;
  MenuUrl: string;
  MenuId: number;
  main_state?: string;
  target?: boolean;
  MenuOrder: number;
  MenuName: string;
  MenuIcon: string;
  ParentId: number;
  SubMenuItems?: SubMenuItems[];
}

const Menus = [
  {
    IsSelected: true,
    MenuAction: [],
    MenuIcon: "fa fa-sitemap",
    MenuId: 0,
    MenuName: "Administrator",
    MenuOrder: 2,
    MenuUrl: "",
    ParentId: 0,
    type : 'sub',
    SubMenuItems: [
      {
        IsSelected: true,
        MenuAction: [],
        MenuIcon: null,
        MenuId: 4,
        MenuName: "RoleLibrary",
        MenuOrder: 3,
        MenuUrl: null,
        type : 'sub',
        ParentId: 2,
        SubMenuItems: [
          {
            IsSelected: true,
            MenuAction: [],
            MenuIcon: null,
            MenuId: 6,
            MenuName: "Creating of Role",
            MenuOrder: 202,
            MenuUrl: 'role',
            ParentId: 4,
            type : 'sub',
            SubMenuItems: []
          }
        ]
      }]
  }
];




const MENUITEMS = JSON.parse((localStorage.getItem('MenuList')))
//console.log('MenuList');

//console.log(MENUITEMS1[1]);
//console.log(MENUITEMS[2]);

@Injectable()
export class MenuItems {
  // menuItems: any;
  // userid: any;
  // MenuList: any;
  // constructor(private http: HttpClient) { }
  // ngOnInit() {
  //   this.http.get(configuration.url + 'User/GetUserMenuByUserId/' + this.userid).subscribe((res: any) => {
  //     this.MenuList = JSON.stringify(res);
  //     console.log(res);
  //     localStorage.setItem('MenuList', this.MenuList)
  //     console.log(this.MenuList)
  //   });

  //}
  getAll() {
    return MENUITEMS
  }
}
