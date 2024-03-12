public class PickupWithDialog : Dialog
{
    private void EndDialog()
    {
        isTalking = false;
        txtBox.ToggleBox(false);
        // give player some item


        Destroy(gameObject);
    }
}
