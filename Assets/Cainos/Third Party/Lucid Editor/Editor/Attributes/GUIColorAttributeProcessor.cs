namespace Cainos.LucidEditor
{
    [CustomAttributeProcessor(typeof(GUIColorAttribute))]
    public class GUIColorAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            GUIColorAttribute guiColor = (GUIColorAttribute)attribute;
            LucidEditorUtility.PushGUIColor(guiColor.useCustomColor ? guiColor.customColor : guiColor.color.ToColor());
        }

        public override void OnAfterDrawProperty()
        {
            LucidEditorUtility.PopGUIColor();
        }
    }
}