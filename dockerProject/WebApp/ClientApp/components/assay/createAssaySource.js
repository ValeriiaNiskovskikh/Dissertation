var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Resource } from "../resource/resource";
import { Source } from "../source/source";
export class AssayResource {
    constructor() {
        this.resource = new Resource();
        this.value = 0.0;
    }
}
let CreateAssaySourceComponent = class CreateAssaySourceComponent extends Vue {
    constructor() {
        super(...arguments);
        this.source = new Source();
        this.assayResources = [];
        this.sourceId = "";
        this.date = new Date();
    }
    mounted() {
    }
    created() {
        this.sourceId = this.$route.params.sourceId;
        fetch('api/v1/source/get/' + this.sourceId)
            .then(response => response.json())
            .then(data => {
            this.source = data;
            for (let r of data.resources) {
                let assayResource = new AssayResource();
                assayResource.resource = r;
                this.assayResources.push(assayResource);
            }
        });
    }
    save() {
        // console.log(this.assayResources);
    }
};
CreateAssaySourceComponent = __decorate([
    Component
], CreateAssaySourceComponent);
export default CreateAssaySourceComponent;
//# sourceMappingURL=createAssaySource.js.map