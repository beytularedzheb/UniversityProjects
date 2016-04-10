package dpteacher.decorator;


public class ExtentionFactory {
    
    public static ExtensionPanel createDecorator(int type, ExtensionPanel panel) {
        ExtensionPanel result = null;
        switch (type) {
            case ExtensionPanel.MYPANEL_EXPANDED :
                result = new ExpandedPanel(panel);
                break;
            case ExtensionPanel.MYPANEL_COMPACT :
                result = new ExtensionPanel();
                break;
        }
        return result;
    }
}
