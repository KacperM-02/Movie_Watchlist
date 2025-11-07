import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.css'
})
export class Header {
  @Input({required: true}) userImg: string="";
  @Input({required: true}) userName: string="User";
}
