export class FarmerPermission {
    canView = false;
    canCreate = false;
    canEdit = false;
    canDelete = false;
    canAccess = false;
}

export class FarmerServicePermission extends FarmerPermission {
}
