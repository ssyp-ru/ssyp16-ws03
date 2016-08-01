import { BaseDataType } from './BaseDataType';
import { Issue } from './Issues/Issue';

export class Sprint extends BaseDataType
{
    public Term: Date;
    public Issues: Array<Issue>;

    public constructor()
    {
        super();
        this.Term = new Date();
        this.Issues = new Array<Issue>();
    }
}