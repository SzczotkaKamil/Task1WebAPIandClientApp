
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public contacts: contact[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<contact[]>(baseUrl + 'api/contact').subscribe(result => {
      this.contacts = result;
    }, error => console.error(error));
  }
}

interface contact {
  id: string;
  name: string;
  lastName: string;
  phoneNumber: string;
  email: string;

}
