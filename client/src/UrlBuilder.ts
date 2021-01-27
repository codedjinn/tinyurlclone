
export interface IParamItem {
    name: string;
    value: string;
    isUri?: boolean;
}

export class UrlBuilder {

    public static AddParams(baseUrl: string, items: IParamItem[]) {
        let first = true;
        let queryStr = "";        
        for (const item of items) {

            let value = item.value;
            if (!!item.isUri) {
                value = encodeURI(item.value);
            }

            if (first) {
                first = false;                
                queryStr = `?${item.name}=${item.value}`;
            }
            else {
                queryStr = `${queryStr}&${item.name}=${item.value}`;
            }            
        }

        return `${baseUrl}${queryStr}`;
    }

}