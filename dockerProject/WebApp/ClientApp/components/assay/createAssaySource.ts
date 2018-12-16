import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import {Resource} from "../resource/resource";
import {Source} from "../source/source";

export class AssayResource{
 resource: Resource;
 value: ConstrainDouble;
}

@Component
export default class CreateAssaySourceComponent extends Vue {
    source: Source;
    assayResources: AssayResource[] = [];
    sourceId : string;
    date: Date = new Date();
    mounted() {
    }
    created(){

        this.sourceId = this.$route.params.sourceId;
        fetch('api/v1/source/get/' + this.sourceId)
            .then(response => response.json() as Promise<Source>)
            .then(data => {
                this.source = data;
                for (let r of data.resources) {
                    let assayResource = new AssayResource();
                    assayResource.resource = r;
                    this.assayResources.push(assayResource)
                }
            })
    }
    save(){
        // console.log(this.assayResources);
    }
    
}
