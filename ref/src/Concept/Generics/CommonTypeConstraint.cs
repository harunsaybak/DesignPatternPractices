namespace MarvellousWorks.PracticalPattern.Concept.Generics
{
    public interface IOrganization { }

    public abstract class UserBase<TKey, TOrganization>
        where TOrganization : class, IOrganization, new()
    {
        // ����Լ�����Է���
        public abstract TOrganization Organization { get;}      

        //  ����Լ������
        public abstract void Promotion(TOrganization newOrganization);

        //  ����Լ��ί��
        delegate TOrganization OrganizationChangedHandler(); 
    }
}
