public class PickupWithDialog : Dialog
{
    private void EndDialog()
    {
        isTalking = false;
        txtBox.ToggleBox(false);
        PlayerMovement.instance.canMove = true;
        // give player some item


        Destroy(gameObject);
    }
}
