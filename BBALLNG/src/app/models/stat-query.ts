export class StatQuery {
    collection: string = "";
    parameters: any[] = [];
    callCount: number = 0;
    parse: boolean = true;
    timeout: number = 15;
}
