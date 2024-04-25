import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css']
})
export class RolesModalComponent implements OnInit {
  // acrescentando as propriedades
  username = '';
  availableRoles: any[] = [];
  selectedRoles: any[] = [];

  constructor(public bsModalRef: BsModalRef) {}

  ngOnInit(): void {    
  }

  updateChecked(checkedValue: string) {
    // verificando o valor do indice,se o indice for = -1, ele não esta dentro da nossa matriz(adiciona/remove)
    const index = this.selectedRoles.indexOf(checkedValue);
    index != -1 ? this.selectedRoles.splice(index, 1) : this.selectedRoles.push(checkedValue);
  }
}
