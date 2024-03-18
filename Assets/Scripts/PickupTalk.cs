public class PickupTalk : Talk
{
    public override void InteractionEnd()
    {
        isInteracting = false;
        txtBox.ToggleBox(false);
        PlayerMovement.instance.canMove = true;
        // give player some item
        Destroy(gameObject);
    }
}
