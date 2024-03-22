import { Component, Input, OnInit, Output } from '@angular/core';
import { EventEmitter } from '@angular/core'
import { AccountService } from '../_services/account.service';
import { response } from 'express';
import { error } from 'console';
import { ToastrService } from 'ngx-toastr';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ThisReceiver } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {  
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup = new FormGroup({});
  maxDate: Date = new Date();
  validationErrors: string[] | undefined;
  
  constructor(private accountService: AccountService, private toastr: ToastrService, 
    private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
      this.initializeForm();
      this.maxDate.setFullYear(this.maxDate.getFullYear() -18);     // = ou maior que 18 anos
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      gender : ['male'],
      username : ['', Validators.required],
      knowAs : ['', Validators.required],
      dateOfBirth : ['', Validators.required],
      city : ['', Validators.required],
      country : ['', Validators.required],
      password : ['', [Validators.required,
        Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword : ['', [Validators.required, this.matchValues('password')]],
    });
    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () => this.registerForm.controls['confirmPassword'].updateValueAndValidity()
    })
  }

  matchValues(matchTo: string): ValidatorFn{
    return (control:AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : {notMatching: true}   // retornando nulo os valores bateram (ok), sendo validado
    }
  }

  register() {   
    const dob = this.getDateOnly(this.registerForm.controls['dateOfBirth'].value);
    const values = {...this.registerForm.value, dateOfBirth: dob};
    // console.log(values);
    this.accountService.register(values).subscribe({
      next: () => {        
        this.router.navigateByUrl('/members')
      },
      error: error => {        
        this.validationErrors = error
      }
    })
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

  // dob: dateOfBirth
  private getDateOnly(dob: string | undefined){
    if (!dob) return;
    let theDob = new Date(dob);
    return new Date(theDob.setMinutes(theDob.getMinutes()-theDob.getTimezoneOffset()))
      .toISOString().slice(0,10);                 // setando para hora local
  }
}
