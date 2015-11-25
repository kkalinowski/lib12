using lib12.DependencyInjection;
using lib12.Test.DependencyInjection.Classes;
using Should;
using Xunit;

namespace lib12.Test.DependencyInjection
{
    public class InstancesTest
    {
        [Fact]
        public void get_singletonclass_is_not_null_test()
        {
            var instance = Instances.Get<SingletonClass>();
            Assert.NotNull(instance);
        }

        [Fact]
        public void instanced_singletonclass_is_same_as_created_by_new_test()
        {
            var instance = Instances.Get<SingletonClass>();
            var newInstance = new SingletonClass();
            Assert.Equal(newInstance.IntProp, instance.IntProp);
        }

        [Fact]
        public void get_singleton_instance_return_same_object_test()
        {
            var newPropValue = 14;
            var instance1 = Instances.Get<SingletonClassThatChangeProperty>();
            instance1.IntProp = newPropValue;
            var instance2 = Instances.Get<SingletonClassThatChangeProperty>();

            Assert.Equal(newPropValue, instance2.IntProp);
            Assert.True(object.ReferenceEquals(instance1, instance2));
        }

        [Fact]
        public void get_transient_instance_return_different_object_test()
        {
            var newPropValue = 14;
            var instance1 = Instances.Get<TransientClass>();
            instance1.IntProp = newPropValue;
            var instance2 = Instances.Get<TransientClass>();

            Assert.NotEqual(newPropValue, instance2.IntProp);
            Assert.False(object.ReferenceEquals(instance1, instance2));
        }

        [Fact]
        public void throws_exception_when_instancing_non_registered_class_test()
        {
            var container = new InstancesContainer();
            Assert.Throws<NotRegisteredTypeException>(() => container.Get<NotRegisteredClass>());
        }

        [Fact]
        public void wire_up_all_attributes_test()
        {
            var instance = Instances.Get<WireAllPropertiesSingleton>();
            Assert.NotNull(instance.Prop1);
            Assert.Equal(SingletonClass.IntPropValue, instance.Prop1.IntProp);
            Assert.NotNull(instance.Prop2);
            Assert.Equal(SingletonClass.IntPropValue, instance.Prop2.IntProp);
        }

        [Fact]
        public void throw_exception_when_get_instance_of_wire_all_properties_with_not_registered_all_properties_test()
        {
            var container = new InstancesContainer();
            Assert.Throws<NotRegisteredTypeException>(() => container.Get<WireAllPropertiesSingletonWithNotRegisteredProperties>());
        }

        [Fact]
        public void inject_in_ctor_test()
        {
            var instance = Instances.Get<InjectInCtor>();
            Assert.NotNull(instance.Prop1);
            Assert.Equal(SingletonClass.IntPropValue, instance.Prop1.IntProp);
        }

        [Fact]
        public void throw_exception_when_class_to_resolve_has_two_ctors_test()
        {
            Assert.Throws<DependencyInjectionException>(() => Instances.Get<InjectInCtor2Ctors>());
        }

        [Fact]
        public void throw_exception_when_inject_in_ctor_not_registered_class_test()
        {
            var container = new InstancesContainer();
            Assert.Throws<NotRegisteredTypeException>(() => container.Get<InjectInCtorNotRegisteredClass>());
        }

        [Fact]
        public void resolve_singleton_by_key_test()
        {
            Instances.RegisterSingleton<SingletonClassRegisteredByKey>("resolve_singleton_by_key");
            var instance = Instances.Get("resolve_singleton_by_key");

            Assert.NotNull(instance);
        }

        [Fact]
        public void throw_exception_when_resolving_unregister_class_by_key_test()
        {
            var container = new InstancesContainer();
            Assert.Throws<NotRegisteredTypeException>(() => container.Get(typeof(NotRegisteredClass).AssemblyQualifiedName));
        }

        [Fact]
        public void throw_exception_when_registered_by_attribute_and_manual_test()
        {
            var container = new InstancesContainer();
            Assert.Throws<DependencyInjectionException>(() => container.RegisterSingleton<RegisteredByAttributeAndManualClass>());
        }

        [Fact]
        public void throw_exception_when_registered_manual_two_times_test()
        {
            var container = new InstancesContainer();
            container.RegisterSingleton<RegisterManualTwoTimesClass>();
            Assert.Throws<DependencyInjectionException>(() => container.RegisterSingleton<RegisterManualTwoTimesClass>());
        }

        [Fact]
        public void throw_exception_when_registered_by_attribute_as_singleton_and_transient_test()
        {
            var container = new InstancesContainer();
            Assert.Throws<DependencyInjectionException>(() => container.Get<RegisterByAttributeAsSingletonAndTransientClass>());
        }

        [Fact]
        public void wire_choosen_properties()
        {
            var instance = Instances.Get<WireChoosenProperties>();
            Assert.NotNull(instance);
            Assert.NotNull(instance.Wired);
            Assert.Null(instance.NotWired);
        }

        [Fact]
        public void wire_up_all_properties_without_ignored()
        {
            var instance = Instances.Get<WireUpAllPropertiesWithoutIgnored>();
            Assert.NotNull(instance);
            Assert.NotNull(instance.Wired);
            Assert.Null(instance.NotWired);
        }

        [Fact]
        public void wire_up_all_properties_with_wire_up_attribute()
        {
            WireUpAllPropertiesWithWireUpAttribute instance = null;
            Assert.DoesNotThrow(() => instance = Instances.Get<WireUpAllPropertiesWithWireUpAttribute>());
            Assert.NotNull(instance);
            Assert.NotNull(instance.Wired);
            Assert.NotNull(instance.AlsoWired);
        }

        [Fact]
        public void do_not_wire_property_with_do_not_wire_attribute_and_without_wire_up_all_properties()
        {
            DoNotWirePropertyWithDoNotWireAttributeAndWithoutWireUpAllProperties instance = null;
            Assert.DoesNotThrow(() => instance = Instances.Get<DoNotWirePropertyWithDoNotWireAttributeAndWithoutWireUpAllProperties>());
            Assert.NotNull(instance);
            Assert.Null(instance.NotWired);
        }

        [Fact]
        public void resolve_circular_dependency_with_property_injection()
        {
            var container = new InstancesContainer();
            CircularDependency1 instance = null;
            Assert.DoesNotThrow(() => instance = container.Get<CircularDependency1>());
            Assert.NotNull(instance);
            Assert.NotNull(instance.CircularDependency2);
            Assert.NotNull(instance.CircularDependency2.CircularDependency1);
        }

        [Fact]
        public void throw_circular_dependency_when_ctor_injecting_exception()
        {
            var container = new InstancesContainer();
            Assert.Throws<CircularDependencyException>(() => container.Get<CircularCtorDependency1>());
        }

        [Fact]
        public void resolve_singleton_by_service()
        {
            Instances.RegisterSingleton<ISingletonContract, SingletonService>();
            Instances.Get<ISingletonContract>().ShouldNotBeNull().ShouldBeType<SingletonService>();
        }

        [Fact]
        public void resolve_transient_by_service()
        {
            Instances.RegisterTransient<ITransientContract, TransientService>();
            Instances.Get<ITransientContract>().ShouldNotBeNull().ShouldBeType<TransientService>();
        }
    }
}
