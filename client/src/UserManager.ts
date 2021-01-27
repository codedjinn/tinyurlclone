import { Constants } from "./Constants";
import { UrlBuilder } from "./UrlBuilder";

export class UserManager {

    public static GetUser(name: string, email: string) {

        // let createUri = UrlBuilder.AddParams(`${Constants.BaseUri}/${Constants.FunctionUri}`,
        //     [
        //         {
        //             name: "type",
        //             value: "create"
        //         },
        //         {
        //             name: "originalUrl",
        //             value: "http://www.google.com",
        //             isUri: true
        //         }
        //     ]);
        // fetch(createUri, {
        //     method: 'GET', // *GET, POST, PUT, DELETE, etc.
        //     mode: 'no-cors', // no-cors, *cors, same-origin
        //     cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        //     credentials: 'omit', // include, *same-origin, omit
        //     headers: {
        //         'Access-Control-Allow-Origin': '*',
        //         'Content-Type': 'application/json'
        //     },
        //     redirect: 'follow',
        //     referrerPolicy: 'no-referrer'
        // })
        // .then(response => console.log(response))
        // .catch(error => console.log(error));

    }

}