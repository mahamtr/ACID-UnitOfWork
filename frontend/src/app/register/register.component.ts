import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  // Private
  private _unsubscribeAll: Subject<any>;

  constructor(
      private _formBuilder: FormBuilder
  )
  {
      // Configure the layout
  
      // Set the private defaults
      this._unsubscribeAll = new Subject();
  }

  // -----------------------------------------------------------------------------------------------------
  // @ Lifecycle hooks
  // -----------------------------------------------------------------------------------------------------

  /**
   * On init
   */
  ngOnInit(): void
  {
      this.registerForm = this._formBuilder.group({
          name           : ['', Validators.required],
          email          : ['', [Validators.required, Validators.email]],
          password       : ['', Validators.required],
          passwordConfirm: ['', [Validators.required, confirmPasswordValidator]]
      });

      // Update the validity of the 'passwordConfirm' field
      // when the 'password' field changes
      this.registerForm.get('password').valueChanges
          .pipe(takeUntil(this._unsubscribeAll))
          .subscribe(() => {
              this.registerForm.get('passwordConfirm').updateValueAndValidity();
          });
  }

  /**
   * On destroy
   */
  ngOnDestroy(): void
  {
      // Unsubscribe from all subscriptions
      this._unsubscribeAll.next();
      this._unsubscribeAll.complete();
  }
}

/**
* Confirm password validator
*
* @param {AbstractControl} control
* @returns {ValidationErrors | null}
*/
export const confirmPasswordValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {

  if ( !control.parent || !control )
  {
      return null;
  }

  const password = control.parent.get('password');
  const passwordConfirm = control.parent.get('passwordConfirm');

  if ( !password || !passwordConfirm )
  {
      return null;
  }

  if ( passwordConfirm.value === '' )
  {
      return null;
  }

  if ( password.value === passwordConfirm.value )
  {
      return null;
  }

  return {passwordsNotMatching: true};
}
