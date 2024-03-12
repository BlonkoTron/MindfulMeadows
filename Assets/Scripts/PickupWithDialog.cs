public class PickupWithDialog : Dialog
{
    public override void EndDialog()
    {
        isTalking = false;
        txtBox.ToggleBox(false);
        PlayerMovement.instance.canMove = true;
        PlayerMovement.instance.canJump = true;
        // give player some item
        Destroy(gameObject);
    }
}
