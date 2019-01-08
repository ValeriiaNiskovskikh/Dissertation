import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import {Resource} from '../resource/resource';


export class Source {
    id: string = "";
    name: string = "";
    resources: Resource[] = [];
}

@Component
export default class SourceComponent extends Vue {
    sources: Source[] = [];
    mounted() {
        fetch('api/v1/source/getAll')
            .then(response => response.json() as Promise<Source[]>)
            .then(data => {
                this.sources = data;
            });
     
    }
    getGroups(count:number){
        let c = 0;
        let result = [];
        let tmp :Source[]=[];
        for (let s of this.sources) {
            c++;
            tmp.push(s);
            if(c==count){
                c=0;
                result.push(tmp);
                tmp=[];
            }
        }
        result.push(tmp);
        return result;
    }
}
