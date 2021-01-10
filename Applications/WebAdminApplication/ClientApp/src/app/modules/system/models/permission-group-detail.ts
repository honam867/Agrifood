import { FarmerPermission } from './Farmer-permission';

export class PermissionGroupDetail {
    id: number;
    name: string;
    description: string;
    users: number[] = [];
    farmerPermission: FarmerPermission = new FarmerPermission();
}
