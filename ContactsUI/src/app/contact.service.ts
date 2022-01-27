import { Injectable } from '@angular/core';
import { Contact } from './Contact';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  contactsUrl : string = "http://localhost:65020/api/contacts";

  constructor(private http: HttpClient) { }

  getContacts() : Observable<Contact[]>{
    return this.http.get<Contact[]>(this.contactsUrl);
  }
}
