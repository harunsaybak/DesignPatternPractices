namespace MarvellousWorks.PracticalPattern.State.Raw
{
    public enum Color { Red, Green, Yellow }

    public class StopLight
    {
        Color current = Color.Yellow;    // default,�������浱ǰ״̬

        /// <summary>
        /// ��һ���űȵ�if else���ת���߼�
        /// </summary>
        /// <returns></returns>
        public Color Next
        {
            get
            {
                if (current == Color.Green)
                    current = Color.Yellow;
                else if (current == Color.Yellow)
                    current = Color.Red;
                else if (current == Color.Red)
                    current = Color.Green;
                return current;
            }
        }
    }
}
