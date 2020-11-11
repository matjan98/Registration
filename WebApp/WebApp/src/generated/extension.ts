import * as generated from "./generated";

export class ClientBase {
    protected transformOptions(requestInit: RequestInit): Promise<RequestInit> {
        console.log("Test");
        if(requestInit && requestInit.headers){
            (requestInit.headers as any).Authorization = "Bearer 123";
        }
        return Promise.resolve<RequestInit>(<any>requestInit);
    }

    protected transformResult(url: string, response: Response, processor: (response: Response) => any) {
        console.log("Service call: " + url);
        return processor(response); 
    }
}