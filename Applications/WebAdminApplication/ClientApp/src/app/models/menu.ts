export class Menu {
  path: string;
  title: string;
  icon: string;
  class: string;
  haveChild: boolean;
  child: SubMenu[] = [];
}

export class SubMenu {
  path: string;
  title: string;
  icon: string;
  class: string;
  haveChild: boolean;
  child: SubMenu[] = [];
}
