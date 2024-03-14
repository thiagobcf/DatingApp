import { Component, Input, OnInit } from '@angular/core';
import { Member } from '../../_models/member';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrl: './photo-editor.component.css'
})
export class PhotoEditorComponent implements OnInit {
  @Input() member: Member | undefined;

  constructor() {}

  ngOnInit(): void {
      
  }

}
