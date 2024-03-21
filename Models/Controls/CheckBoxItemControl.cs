using System.Collections.Generic;

namespace ExpensesManager.Models.Controls
{
    class CheckBoxItemControl
    {
        private bool flagUnSelect = true;
        private bool flagSelect = false;
        public void activateOne(object currentItem, List<OrderParameter> _checkBoxList)
        {

            var currentParam = currentItem as OrderParameter;

            foreach (OrderParameter item in _checkBoxList)
            {
                if (item.id == currentParam.id) continue;
                item.value = !currentParam.value;
            }

        }

        public void activateAll(object currentItem, List<OrderParameter> _checkBoxList, string expectedLabel = "Выделить все")
        {
            var currentParam = currentItem as OrderParameter;

            if (currentParam.name == expectedLabel && flagUnSelect)
            {
                flagSelect = true;

                foreach (OrderParameter item in _checkBoxList)
                {
                    if (item.id == currentParam.id) continue;
                    item.value = currentParam.value;
                }

                flagSelect = false;
            }
            else
            {
                if (flagSelect) { return; }
                if (!currentParam.value && flagUnSelect && currentParam.name != expectedLabel)
                {
                    foreach (OrderParameter item in _checkBoxList)
                    {
                        if (item.name == expectedLabel)
                        {
                            if (!item.value) break;
                            flagUnSelect = false;
                            item.value = false;
                            break;
                        }
                    }
                }
                else
                {
                    flagUnSelect = true;
                }
            }

        }

    }
}
