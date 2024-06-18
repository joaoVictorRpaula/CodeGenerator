import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn:'root'
  })
export class CodeGeneratorEndpoint {
    
    get endpoint(): string {
        return "/CodeGenerator";
    }

    constructor(private httpClient : HttpClient) {}

    getAllTemplates() : Observable<string[]>{
        var generateEndpoint = "/GetAllTemplates";
        return this.httpClient.get<string[]>(environment.apiUrl + this.endpoint + generateEndpoint)
    }

    getAllLanguages() : Observable<string[]>{
        var generateEndpoint = "/GetAllLanguages";
        return this.httpClient.get<string[]>(environment.apiUrl + this.endpoint + generateEndpoint)
    }
    
}
