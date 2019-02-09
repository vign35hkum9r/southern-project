

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
console.log('MenuList')
console.log(MENUITEMS)

export class MenuItems {

}
