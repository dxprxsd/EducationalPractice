PGDMP  5    #                }            informationsecuritydb    17.4    17.4 p    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    16553    informationsecuritydb    DATABASE     {   CREATE DATABASE informationsecuritydb WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'ru-RU';
 %   DROP DATABASE informationsecuritydb;
                     postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                     pg_database_owner    false            �           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                        pg_database_owner    false    4            �            1259    16609 
   activities    TABLE     h   CREATE TABLE public.activities (
    activitiesid integer NOT NULL,
    activitiesname text NOT NULL
);
    DROP TABLE public.activities;
       public         heap r       postgres    false    4            �            1259    16608    activities_activitiesid_seq    SEQUENCE     �   CREATE SEQUENCE public.activities_activitiesid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public.activities_activitiesid_seq;
       public               postgres    false    4    228            �           0    0    activities_activitiesid_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public.activities_activitiesid_seq OWNED BY public.activities.activitiesid;
          public               postgres    false    227            �            1259    16582    cities    TABLE     u   CREATE TABLE public.cities (
    idcity integer NOT NULL,
    cityname text NOT NULL,
    cityimage text NOT NULL
);
    DROP TABLE public.cities;
       public         heap r       postgres    false    4            �            1259    16581    cities_idcity_seq    SEQUENCE     �   CREATE SEQUENCE public.cities_idcity_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.cities_idcity_seq;
       public               postgres    false    224    4            �           0    0    cities_idcity_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.cities_idcity_seq OWNED BY public.cities.idcity;
          public               postgres    false    223            �            1259    16618    client    TABLE     �  CREATE TABLE public.client (
    idclient integer NOT NULL,
    snameclient character varying(100) NOT NULL,
    nameclient character varying(100) NOT NULL,
    patronymicclient character varying(100) NOT NULL,
    email text NOT NULL,
    dob timestamp without time zone NOT NULL,
    countryid integer NOT NULL,
    phonenumber character varying(20) NOT NULL,
    password text NOT NULL,
    photo text NOT NULL,
    genderid integer NOT NULL
);
    DROP TABLE public.client;
       public         heap r       postgres    false    4            �            1259    16617    client_idclient_seq    SEQUENCE     �   CREATE SEQUENCE public.client_idclient_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.client_idclient_seq;
       public               postgres    false    4    230            �           0    0    client_idclient_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.client_idclient_seq OWNED BY public.client.idclient;
          public               postgres    false    229            �            1259    16573 	   countries    TABLE     �   CREATE TABLE public.countries (
    idcountry integer NOT NULL,
    countryname text NOT NULL,
    countrynameeng text NOT NULL,
    firstcode character(5) NOT NULL,
    secondcode integer NOT NULL
);
    DROP TABLE public.countries;
       public         heap r       postgres    false    4            �            1259    16572    countries_idcountry_seq    SEQUENCE     �   CREATE SEQUENCE public.countries_idcountry_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.countries_idcountry_seq;
       public               postgres    false    222    4            �           0    0    countries_idcountry_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.countries_idcountry_seq OWNED BY public.countries.idcountry;
          public               postgres    false    221            �            1259    16555 
   directions    TABLE     g   CREATE TABLE public.directions (
    iddirections integer NOT NULL,
    directionname text NOT NULL
);
    DROP TABLE public.directions;
       public         heap r       postgres    false    4            �            1259    16554    directions_iddirections_seq    SEQUENCE     �   CREATE SEQUENCE public.directions_iddirections_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public.directions_iddirections_seq;
       public               postgres    false    4    218            �           0    0    directions_iddirections_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public.directions_iddirections_seq OWNED BY public.directions.iddirections;
          public               postgres    false    217            �            1259    16600    genders    TABLE     ]   CREATE TABLE public.genders (
    idgender integer NOT NULL,
    gendername text NOT NULL
);
    DROP TABLE public.genders;
       public         heap r       postgres    false    4            �            1259    16599    genders_idgender_seq    SEQUENCE     �   CREATE SEQUENCE public.genders_idgender_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.genders_idgender_seq;
       public               postgres    false    4    226            �           0    0    genders_idgender_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.genders_idgender_seq OWNED BY public.genders.idgender;
          public               postgres    false    225            �            1259    16656    jury    TABLE     �  CREATE TABLE public.jury (
    juryid integer NOT NULL,
    snamejury character varying(100) NOT NULL,
    namejury character varying(100) NOT NULL,
    patronymicjury character varying(100) NOT NULL,
    genderid integer NOT NULL,
    email text,
    dob timestamp without time zone,
    countryid integer,
    phonenumber character varying(20) NOT NULL,
    directionsid integer,
    password text NOT NULL,
    photo text
);
    DROP TABLE public.jury;
       public         heap r       postgres    false    4            �            1259    16655    jury_juryid_seq    SEQUENCE     �   CREATE SEQUENCE public.jury_juryid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.jury_juryid_seq;
       public               postgres    false    4    234            �           0    0    jury_juryid_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.jury_juryid_seq OWNED BY public.jury.juryid;
          public               postgres    false    233            �            1259    16729    meropriyatie    TABLE     �   CREATE TABLE public.meropriyatie (
    meropriyatieid integer NOT NULL,
    meropriyatiename text NOT NULL,
    meropriyatiedate timestamp without time zone NOT NULL,
    cityid integer NOT NULL,
    photo text,
    directionsid integer
);
     DROP TABLE public.meropriyatie;
       public         heap r       postgres    false    4            �            1259    16728    meropriyatie_meropriyatieid_seq    SEQUENCE     �   CREATE SEQUENCE public.meropriyatie_meropriyatieid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public.meropriyatie_meropriyatieid_seq;
       public               postgres    false    238    4            �           0    0    meropriyatie_meropriyatieid_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public.meropriyatie_meropriyatieid_seq OWNED BY public.meropriyatie.meropriyatieid;
          public               postgres    false    237            �            1259    16893    meropriyatieandactivities    TABLE       CREATE TABLE public.meropriyatieandactivities (
    meropriyatieandactivitiesid integer NOT NULL,
    idmeropriyatie integer NOT NULL,
    startdate timestamp without time zone NOT NULL,
    dayscount integer NOT NULL,
    idactivities integer NOT NULL,
    numberday integer NOT NULL,
    timestart time without time zone NOT NULL,
    idmoderator integer NOT NULL,
    firstjury integer,
    secondjury integer,
    thirdjury integer,
    fourthjury integer,
    fifthjury integer,
    winnerid integer NOT NULL
);
 -   DROP TABLE public.meropriyatieandactivities;
       public         heap r       postgres    false    4            �            1259    16892 9   meropriyatieandactivities_meropriyatieandactivitiesid_seq    SEQUENCE     �   CREATE SEQUENCE public.meropriyatieandactivities_meropriyatieandactivitiesid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 P   DROP SEQUENCE public.meropriyatieandactivities_meropriyatieandactivitiesid_seq;
       public               postgres    false    4    240            �           0    0 9   meropriyatieandactivities_meropriyatieandactivitiesid_seq    SEQUENCE OWNED BY     �   ALTER SEQUENCE public.meropriyatieandactivities_meropriyatieandactivitiesid_seq OWNED BY public.meropriyatieandactivities.meropriyatieandactivitiesid;
          public               postgres    false    239            �            1259    16699 
   moderators    TABLE     �  CREATE TABLE public.moderators (
    moderatorid integer NOT NULL,
    snamemoderator character varying(100) NOT NULL,
    namemoderator character varying(100) NOT NULL,
    patronymicmoderator character varying(100) NOT NULL,
    genderid integer NOT NULL,
    email text,
    dob timestamp without time zone,
    countryid integer,
    phonenumber character varying(20),
    directionsid integer,
    sobitieid integer,
    password text NOT NULL,
    photo text
);
    DROP TABLE public.moderators;
       public         heap r       postgres    false    4            �            1259    16698    moderators_moderatorid_seq    SEQUENCE     �   CREATE SEQUENCE public.moderators_moderatorid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.moderators_moderatorid_seq;
       public               postgres    false    236    4            �           0    0    moderators_moderatorid_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.moderators_moderatorid_seq OWNED BY public.moderators.moderatorid;
          public               postgres    false    235            �            1259    16637 
   organizers    TABLE     �  CREATE TABLE public.organizers (
    idorganizer integer NOT NULL,
    snameorganizer character varying(100) NOT NULL,
    nameorganizer character varying(100) NOT NULL,
    patronymicorganizer character varying(100) NOT NULL,
    email text NOT NULL,
    dob timestamp without time zone NOT NULL,
    countryid integer NOT NULL,
    phonenumber character varying(20) NOT NULL,
    password text,
    photo text NOT NULL,
    genderid integer
);
    DROP TABLE public.organizers;
       public         heap r       postgres    false    4            �            1259    16636    organizers_idorganizer_seq    SEQUENCE     �   CREATE SEQUENCE public.organizers_idorganizer_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.organizers_idorganizer_seq;
       public               postgres    false    4    232            �           0    0    organizers_idorganizer_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.organizers_idorganizer_seq OWNED BY public.organizers.idorganizer;
          public               postgres    false    231            �            1259    16564    sobitie    TABLE     _   CREATE TABLE public.sobitie (
    idsobitie integer NOT NULL,
    sobitiename text NOT NULL
);
    DROP TABLE public.sobitie;
       public         heap r       postgres    false    4            �            1259    16563    sobitie_idsobitie_seq    SEQUENCE     �   CREATE SEQUENCE public.sobitie_idsobitie_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public.sobitie_idsobitie_seq;
       public               postgres    false    4    220            �           0    0    sobitie_idsobitie_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public.sobitie_idsobitie_seq OWNED BY public.sobitie.idsobitie;
          public               postgres    false    219            �           2604    16612    activities activitiesid    DEFAULT     �   ALTER TABLE ONLY public.activities ALTER COLUMN activitiesid SET DEFAULT nextval('public.activities_activitiesid_seq'::regclass);
 F   ALTER TABLE public.activities ALTER COLUMN activitiesid DROP DEFAULT;
       public               postgres    false    228    227    228            �           2604    16585    cities idcity    DEFAULT     n   ALTER TABLE ONLY public.cities ALTER COLUMN idcity SET DEFAULT nextval('public.cities_idcity_seq'::regclass);
 <   ALTER TABLE public.cities ALTER COLUMN idcity DROP DEFAULT;
       public               postgres    false    224    223    224            �           2604    16621    client idclient    DEFAULT     r   ALTER TABLE ONLY public.client ALTER COLUMN idclient SET DEFAULT nextval('public.client_idclient_seq'::regclass);
 >   ALTER TABLE public.client ALTER COLUMN idclient DROP DEFAULT;
       public               postgres    false    229    230    230            �           2604    16576    countries idcountry    DEFAULT     z   ALTER TABLE ONLY public.countries ALTER COLUMN idcountry SET DEFAULT nextval('public.countries_idcountry_seq'::regclass);
 B   ALTER TABLE public.countries ALTER COLUMN idcountry DROP DEFAULT;
       public               postgres    false    222    221    222            �           2604    16558    directions iddirections    DEFAULT     �   ALTER TABLE ONLY public.directions ALTER COLUMN iddirections SET DEFAULT nextval('public.directions_iddirections_seq'::regclass);
 F   ALTER TABLE public.directions ALTER COLUMN iddirections DROP DEFAULT;
       public               postgres    false    217    218    218            �           2604    16603    genders idgender    DEFAULT     t   ALTER TABLE ONLY public.genders ALTER COLUMN idgender SET DEFAULT nextval('public.genders_idgender_seq'::regclass);
 ?   ALTER TABLE public.genders ALTER COLUMN idgender DROP DEFAULT;
       public               postgres    false    225    226    226            �           2604    16659    jury juryid    DEFAULT     j   ALTER TABLE ONLY public.jury ALTER COLUMN juryid SET DEFAULT nextval('public.jury_juryid_seq'::regclass);
 :   ALTER TABLE public.jury ALTER COLUMN juryid DROP DEFAULT;
       public               postgres    false    233    234    234            �           2604    16732    meropriyatie meropriyatieid    DEFAULT     �   ALTER TABLE ONLY public.meropriyatie ALTER COLUMN meropriyatieid SET DEFAULT nextval('public.meropriyatie_meropriyatieid_seq'::regclass);
 J   ALTER TABLE public.meropriyatie ALTER COLUMN meropriyatieid DROP DEFAULT;
       public               postgres    false    237    238    238            �           2604    16896 5   meropriyatieandactivities meropriyatieandactivitiesid    DEFAULT     �   ALTER TABLE ONLY public.meropriyatieandactivities ALTER COLUMN meropriyatieandactivitiesid SET DEFAULT nextval('public.meropriyatieandactivities_meropriyatieandactivitiesid_seq'::regclass);
 d   ALTER TABLE public.meropriyatieandactivities ALTER COLUMN meropriyatieandactivitiesid DROP DEFAULT;
       public               postgres    false    239    240    240            �           2604    16702    moderators moderatorid    DEFAULT     �   ALTER TABLE ONLY public.moderators ALTER COLUMN moderatorid SET DEFAULT nextval('public.moderators_moderatorid_seq'::regclass);
 E   ALTER TABLE public.moderators ALTER COLUMN moderatorid DROP DEFAULT;
       public               postgres    false    236    235    236            �           2604    16640    organizers idorganizer    DEFAULT     �   ALTER TABLE ONLY public.organizers ALTER COLUMN idorganizer SET DEFAULT nextval('public.organizers_idorganizer_seq'::regclass);
 E   ALTER TABLE public.organizers ALTER COLUMN idorganizer DROP DEFAULT;
       public               postgres    false    232    231    232            �           2604    16567    sobitie idsobitie    DEFAULT     v   ALTER TABLE ONLY public.sobitie ALTER COLUMN idsobitie SET DEFAULT nextval('public.sobitie_idsobitie_seq'::regclass);
 @   ALTER TABLE public.sobitie ALTER COLUMN idsobitie DROP DEFAULT;
       public               postgres    false    220    219    220            �          0    16609 
   activities 
   TABLE DATA           B   COPY public.activities (activitiesid, activitiesname) FROM stdin;
    public               postgres    false    228   ��       �          0    16582    cities 
   TABLE DATA           =   COPY public.cities (idcity, cityname, cityimage) FROM stdin;
    public               postgres    false    224   ,�       �          0    16618    client 
   TABLE DATA           �   COPY public.client (idclient, snameclient, nameclient, patronymicclient, email, dob, countryid, phonenumber, password, photo, genderid) FROM stdin;
    public               postgres    false    230   ��       �          0    16573 	   countries 
   TABLE DATA           b   COPY public.countries (idcountry, countryname, countrynameeng, firstcode, secondcode) FROM stdin;
    public               postgres    false    222   ��       �          0    16555 
   directions 
   TABLE DATA           A   COPY public.directions (iddirections, directionname) FROM stdin;
    public               postgres    false    218   v�       �          0    16600    genders 
   TABLE DATA           7   COPY public.genders (idgender, gendername) FROM stdin;
    public               postgres    false    226   ��       �          0    16656    jury 
   TABLE DATA           �   COPY public.jury (juryid, snamejury, namejury, patronymicjury, genderid, email, dob, countryid, phonenumber, directionsid, password, photo) FROM stdin;
    public               postgres    false    234   4�       �          0    16729    meropriyatie 
   TABLE DATA           w   COPY public.meropriyatie (meropriyatieid, meropriyatiename, meropriyatiedate, cityid, photo, directionsid) FROM stdin;
    public               postgres    false    238   ��       �          0    16893    meropriyatieandactivities 
   TABLE DATA           �   COPY public.meropriyatieandactivities (meropriyatieandactivitiesid, idmeropriyatie, startdate, dayscount, idactivities, numberday, timestart, idmoderator, firstjury, secondjury, thirdjury, fourthjury, fifthjury, winnerid) FROM stdin;
    public               postgres    false    240   ��       �          0    16699 
   moderators 
   TABLE DATA           �   COPY public.moderators (moderatorid, snamemoderator, namemoderator, patronymicmoderator, genderid, email, dob, countryid, phonenumber, directionsid, sobitieid, password, photo) FROM stdin;
    public               postgres    false    236   w�       �          0    16637 
   organizers 
   TABLE DATA           �   COPY public.organizers (idorganizer, snameorganizer, nameorganizer, patronymicorganizer, email, dob, countryid, phonenumber, password, photo, genderid) FROM stdin;
    public               postgres    false    232   ��       �          0    16564    sobitie 
   TABLE DATA           9   COPY public.sobitie (idsobitie, sobitiename) FROM stdin;
    public               postgres    false    220   ��       �           0    0    activities_activitiesid_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public.activities_activitiesid_seq', 1, false);
          public               postgres    false    227            �           0    0    cities_idcity_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.cities_idcity_seq', 1, false);
          public               postgres    false    223            �           0    0    client_idclient_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.client_idclient_seq', 1, false);
          public               postgres    false    229            �           0    0    countries_idcountry_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.countries_idcountry_seq', 1, false);
          public               postgres    false    221            �           0    0    directions_iddirections_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public.directions_iddirections_seq', 1, false);
          public               postgres    false    217            �           0    0    genders_idgender_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.genders_idgender_seq', 1, false);
          public               postgres    false    225            �           0    0    jury_juryid_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.jury_juryid_seq', 14, true);
          public               postgres    false    233            �           0    0    meropriyatie_meropriyatieid_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public.meropriyatie_meropriyatieid_seq', 1, false);
          public               postgres    false    237            �           0    0 9   meropriyatieandactivities_meropriyatieandactivitiesid_seq    SEQUENCE SET     h   SELECT pg_catalog.setval('public.meropriyatieandactivities_meropriyatieandactivitiesid_seq', 1, false);
          public               postgres    false    239            �           0    0    moderators_moderatorid_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public.moderators_moderatorid_seq', 25, true);
          public               postgres    false    235            �           0    0    organizers_idorganizer_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public.organizers_idorganizer_seq', 1, false);
          public               postgres    false    231            �           0    0    sobitie_idsobitie_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.sobitie_idsobitie_seq', 1, false);
          public               postgres    false    219            �           2606    16616    activities activities_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.activities
    ADD CONSTRAINT activities_pkey PRIMARY KEY (activitiesid);
 D   ALTER TABLE ONLY public.activities DROP CONSTRAINT activities_pkey;
       public                 postgres    false    228            �           2606    16589    cities cities_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.cities
    ADD CONSTRAINT cities_pkey PRIMARY KEY (idcity);
 <   ALTER TABLE ONLY public.cities DROP CONSTRAINT cities_pkey;
       public                 postgres    false    224            �           2606    16625    client client_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_pkey PRIMARY KEY (idclient);
 <   ALTER TABLE ONLY public.client DROP CONSTRAINT client_pkey;
       public                 postgres    false    230            �           2606    16580    countries countries_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public.countries
    ADD CONSTRAINT countries_pkey PRIMARY KEY (idcountry);
 B   ALTER TABLE ONLY public.countries DROP CONSTRAINT countries_pkey;
       public                 postgres    false    222            �           2606    16562    directions directions_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.directions
    ADD CONSTRAINT directions_pkey PRIMARY KEY (iddirections);
 D   ALTER TABLE ONLY public.directions DROP CONSTRAINT directions_pkey;
       public                 postgres    false    218            �           2606    16607    genders genders_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.genders
    ADD CONSTRAINT genders_pkey PRIMARY KEY (idgender);
 >   ALTER TABLE ONLY public.genders DROP CONSTRAINT genders_pkey;
       public                 postgres    false    226            �           2606    16663    jury jury_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.jury
    ADD CONSTRAINT jury_pkey PRIMARY KEY (juryid);
 8   ALTER TABLE ONLY public.jury DROP CONSTRAINT jury_pkey;
       public                 postgres    false    234            �           2606    16736    meropriyatie meropriyatie_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.meropriyatie
    ADD CONSTRAINT meropriyatie_pkey PRIMARY KEY (meropriyatieid);
 H   ALTER TABLE ONLY public.meropriyatie DROP CONSTRAINT meropriyatie_pkey;
       public                 postgres    false    238            �           2606    16898 8   meropriyatieandactivities meropriyatieandactivities_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_pkey PRIMARY KEY (meropriyatieandactivitiesid);
 b   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_pkey;
       public                 postgres    false    240            �           2606    16706    moderators moderators_pkey 
   CONSTRAINT     a   ALTER TABLE ONLY public.moderators
    ADD CONSTRAINT moderators_pkey PRIMARY KEY (moderatorid);
 D   ALTER TABLE ONLY public.moderators DROP CONSTRAINT moderators_pkey;
       public                 postgres    false    236            �           2606    16644    organizers organizers_pkey 
   CONSTRAINT     a   ALTER TABLE ONLY public.organizers
    ADD CONSTRAINT organizers_pkey PRIMARY KEY (idorganizer);
 D   ALTER TABLE ONLY public.organizers DROP CONSTRAINT organizers_pkey;
       public                 postgres    false    232            �           2606    16571    sobitie sobitie_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public.sobitie
    ADD CONSTRAINT sobitie_pkey PRIMARY KEY (idsobitie);
 >   ALTER TABLE ONLY public.sobitie DROP CONSTRAINT sobitie_pkey;
       public                 postgres    false    220            �           2606    16631    client client_countryid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_countryid_fkey FOREIGN KEY (countryid) REFERENCES public.countries(idcountry);
 F   ALTER TABLE ONLY public.client DROP CONSTRAINT client_countryid_fkey;
       public               postgres    false    222    4814    230            �           2606    16626    client client_genderid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_genderid_fkey FOREIGN KEY (genderid) REFERENCES public.genders(idgender);
 E   ALTER TABLE ONLY public.client DROP CONSTRAINT client_genderid_fkey;
       public               postgres    false    4818    226    230            �           2606    16674    jury jury_countryid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.jury
    ADD CONSTRAINT jury_countryid_fkey FOREIGN KEY (countryid) REFERENCES public.countries(idcountry);
 B   ALTER TABLE ONLY public.jury DROP CONSTRAINT jury_countryid_fkey;
       public               postgres    false    4814    234    222            �           2606    16669    jury jury_directionsid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.jury
    ADD CONSTRAINT jury_directionsid_fkey FOREIGN KEY (directionsid) REFERENCES public.directions(iddirections);
 E   ALTER TABLE ONLY public.jury DROP CONSTRAINT jury_directionsid_fkey;
       public               postgres    false    4810    218    234            �           2606    16664    jury jury_genderid_fkey    FK CONSTRAINT        ALTER TABLE ONLY public.jury
    ADD CONSTRAINT jury_genderid_fkey FOREIGN KEY (genderid) REFERENCES public.genders(idgender);
 A   ALTER TABLE ONLY public.jury DROP CONSTRAINT jury_genderid_fkey;
       public               postgres    false    4818    226    234            �           2606    16737 %   meropriyatie meropriyatie_cityid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatie
    ADD CONSTRAINT meropriyatie_cityid_fkey FOREIGN KEY (cityid) REFERENCES public.cities(idcity);
 O   ALTER TABLE ONLY public.meropriyatie DROP CONSTRAINT meropriyatie_cityid_fkey;
       public               postgres    false    224    4816    238            �           2606    16944 '   meropriyatie meropriyatie_directions_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatie
    ADD CONSTRAINT meropriyatie_directions_fk FOREIGN KEY (directionsid) REFERENCES public.directions(iddirections);
 Q   ALTER TABLE ONLY public.meropriyatie DROP CONSTRAINT meropriyatie_directions_fk;
       public               postgres    false    4810    218    238            �           2606    16934 B   meropriyatieandactivities meropriyatieandactivities_fifthjury_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_fifthjury_fkey FOREIGN KEY (fifthjury) REFERENCES public.jury(juryid);
 l   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_fifthjury_fkey;
       public               postgres    false    240    234    4826            �           2606    16914 B   meropriyatieandactivities meropriyatieandactivities_firstjury_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_firstjury_fkey FOREIGN KEY (firstjury) REFERENCES public.jury(juryid);
 l   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_firstjury_fkey;
       public               postgres    false    234    240    4826            �           2606    16929 C   meropriyatieandactivities meropriyatieandactivities_fourthjury_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_fourthjury_fkey FOREIGN KEY (fourthjury) REFERENCES public.jury(juryid);
 m   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_fourthjury_fkey;
       public               postgres    false    4826    240    234            �           2606    16904 E   meropriyatieandactivities meropriyatieandactivities_idactivities_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_idactivities_fkey FOREIGN KEY (idactivities) REFERENCES public.activities(activitiesid);
 o   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_idactivities_fkey;
       public               postgres    false    240    4820    228            �           2606    16899 G   meropriyatieandactivities meropriyatieandactivities_idmeropriyatie_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_idmeropriyatie_fkey FOREIGN KEY (idmeropriyatie) REFERENCES public.meropriyatie(meropriyatieid);
 q   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_idmeropriyatie_fkey;
       public               postgres    false    238    4830    240            �           2606    16909 D   meropriyatieandactivities meropriyatieandactivities_idmoderator_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_idmoderator_fkey FOREIGN KEY (idmoderator) REFERENCES public.moderators(moderatorid);
 n   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_idmoderator_fkey;
       public               postgres    false    236    4828    240            �           2606    16919 C   meropriyatieandactivities meropriyatieandactivities_secondjury_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_secondjury_fkey FOREIGN KEY (secondjury) REFERENCES public.jury(juryid);
 m   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_secondjury_fkey;
       public               postgres    false    4826    234    240            �           2606    16924 B   meropriyatieandactivities meropriyatieandactivities_thirdjury_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_thirdjury_fkey FOREIGN KEY (thirdjury) REFERENCES public.jury(juryid);
 l   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_thirdjury_fkey;
       public               postgres    false    240    234    4826            �           2606    16939 A   meropriyatieandactivities meropriyatieandactivities_winnerid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.meropriyatieandactivities
    ADD CONSTRAINT meropriyatieandactivities_winnerid_fkey FOREIGN KEY (winnerid) REFERENCES public.client(idclient);
 k   ALTER TABLE ONLY public.meropriyatieandactivities DROP CONSTRAINT meropriyatieandactivities_winnerid_fkey;
       public               postgres    false    230    4822    240            �           2606    16722 $   moderators moderators_countryid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.moderators
    ADD CONSTRAINT moderators_countryid_fkey FOREIGN KEY (countryid) REFERENCES public.countries(idcountry);
 N   ALTER TABLE ONLY public.moderators DROP CONSTRAINT moderators_countryid_fkey;
       public               postgres    false    4814    236    222            �           2606    16712 '   moderators moderators_directionsid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.moderators
    ADD CONSTRAINT moderators_directionsid_fkey FOREIGN KEY (directionsid) REFERENCES public.directions(iddirections);
 Q   ALTER TABLE ONLY public.moderators DROP CONSTRAINT moderators_directionsid_fkey;
       public               postgres    false    218    4810    236            �           2606    16707 #   moderators moderators_genderid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.moderators
    ADD CONSTRAINT moderators_genderid_fkey FOREIGN KEY (genderid) REFERENCES public.genders(idgender);
 M   ALTER TABLE ONLY public.moderators DROP CONSTRAINT moderators_genderid_fkey;
       public               postgres    false    226    4818    236            �           2606    16717 $   moderators moderators_sobitieid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.moderators
    ADD CONSTRAINT moderators_sobitieid_fkey FOREIGN KEY (sobitieid) REFERENCES public.sobitie(idsobitie);
 N   ALTER TABLE ONLY public.moderators DROP CONSTRAINT moderators_sobitieid_fkey;
       public               postgres    false    220    4812    236            �           2606    16650 $   organizers organizers_countryid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.organizers
    ADD CONSTRAINT organizers_countryid_fkey FOREIGN KEY (countryid) REFERENCES public.countries(idcountry);
 N   ALTER TABLE ONLY public.organizers DROP CONSTRAINT organizers_countryid_fkey;
       public               postgres    false    222    232    4814            �           2606    16645 #   organizers organizers_genderid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.organizers
    ADD CONSTRAINT organizers_genderid_fkey FOREIGN KEY (genderid) REFERENCES public.genders(idgender);
 M   ALTER TABLE ONLY public.organizers DROP CONSTRAINT organizers_genderid_fkey;
       public               postgres    false    226    4818    232            �   x  x��T=o�P�����/M�L^���� �C
sR+�B%�P!�X]'n�;�Ĺ��1�*�8y�_�s�#ÿ��ol�e������ל�q��~̹�S^��/.����چr�b9�4JP���
*��[A��� PI4������qL��x���=&��Y�-�{iS�����N�S��Տ-��dց��2��\��N� ��_��R.c:| Q�'������/���?rR�Z��"�3eJ�E��������]js��x}.N�(�(�9�{�����ڢZ���p���{���D�P(�W�`����I� 8�p��� ���
���O��OѡP6��+�[ ����M�H�Hx-�4	��Oۭ*���t�/@����exS�3|�Cjʠ�h�T���Y˕�9��y��թ��y}r�'�nQ:&	r���6l�T��N_��F����2,�Z@H�pB� ������#���U�}���_�'�2�4�m����J�Mb��ս��X�)��8H��F���\�9zy��D�1iC�Dm��yk3��y'a��;��C(z���\o�6�6� a�6��V6\�ȶ���A*�]{������A      �      x���K�7��ǬUhy-��r'=h�փn�%�I��2��+QR�E�]�R�D23ɬ|n��:��w�yX�I�����#�8 wg�����w�O�ww����o���ݿ����������K�x����ߝ�Nw��+��F�����;�H�H���9ޝ��o��X�X���ݛ�v����^����_����c|c�h���
�*Ov�Z*Ǜįv䯍�������{��ܿ�K�ǽ/"q,Y�����-�}9_�����]��4v-W3�׉9.Bqsx��z����A.I�x8���%2y��"W4&�{��uwܳ�\���|����?Q�^��`����_�H�����.�3}���՜��L^���(/6{�y}������>"v�����^/��|�~��Z _�E��j�V_�cabb�g��q;����b_5z�Y,�M"G�w�[ů�H�l>�O_��#�_����z�ka�Ű��1��}ς���OW�q!�.[wM������ �b^`��2��bbaH�x$�1����>~�.���!�"ѣ��Q�A�U"�|m��b`h����"<*7�P�m�I�j���G�)z��#�a��Q��ћ�S]�j.r��Ky��bҸ~N��������DěXLd~3�x��x��x�+~I/��\K�|���ط{kM}rs��u�����LݞıĎ�z*a��^��k�];$���'q-�k���߶	���p�{�H��$��շo�+y?� I<KQ��-<?I�JM�V��6$q(/9�{]�z��r��Wv��?g��Y|�^�)��X��""n刈�È�O9I�w�W���Ѩ�9���\.=�����Ź\G���v<�qq.7�ol�ʢ�}>��U��9{j�t�W\�l��"����������V"�k��g�0L�+nqk}:ק��+�kGw�;�j�����W�#?��I����z%\ĸ�&�/\�ߧ�z�N���uQ���k�c�o���4~Bo�^m'�Gt�/P:U�A?w���b��0�Mk1���e/k��B��e(>Qkb��ա8�^�y�XY��\l~Gl�P��t�h��6q�u'�gS�M�l~�?�[�&��0T�ר񮉯m�z��ֵ��M�]��_��J-��mq���p����
q�U(������������J;�b�<7�����^��o�y���x�bAb�`�����<��=��G���I/	*���K/Yc�H#g5�S/ehj=�m�>����0�
(ۿT�M�X�Tn��]��u�󩋯l�D�!�7O��+���*T)\��)���Q��V^qih��v�q8�2�����I�p��s�����2��gF�_�T&N��5Q�K[�p�/�o؝(��U�z|��K�P��C����P�<\=��Fᦏ���Hq!�G�V/����>��k=�Xc����r�s$m��
��|U%�%h��f�`gXF�xzIA+�p�[�7Y���'�
?H��=/�+枷�8�o��(BpNG.�)�8��[�o*)��#V!��Z�]n�v��YH������O"��	���PT_d`�#n����$��E��>��W�0�b��cq�w��86��G�Q���&��C�����1�H�1��O��=#Ɨ�J�+\���|��~��8����2X|�;R)&��n�1��w��רwr��|'M�Z��yXA;�pGU�Z�w\�q��E�|\
V˷�?�#0ȥxK���˹�쒎
%#^;k��%�m�s@r)ߒ��C�(�TnI������:�W�4�
Ő�U��-��e�=��y���\Fq�{ԯ(�2	5���L�$z�>H�X�ϱǷ��V.��|'w�q�u@.���|�07���<�@�0W�hSC�:x��՝1�ҿ?���fuf���
{+��0k� ^�8�9���r�վ����T��F�t�S��\I�@�E���?��\���24g�ߵU�:8]j���r*s�A15� 1W�_��Ln �\Uw��(檸JcQT��{��4N��I���c�F����=��Uq�~�K�ަĀe���<>3?��2G\��\�e[u0�ܤ���{�(sDe߭����9���Q�G5�9��5�%t�i�b�H�m�9"0�Rcj3��#���kOԻ�P<\ۏ�e��@컵2[U*;�K	�D3!���V�:* 2�����M��%?CT�j��������#��'d�rҗ�� �rK|��]�=@��=�V�u ��	֞p��.o�7��	ٞ�Az��'P{�A���H<���r<&0O���Nx�w���@4O���k��8<���\����1"�4��*wf&:6�g���8��`���>��Zx �w����y\�Ƽ���a���a�ixʃȼ�F��f.��2�RW�R��\�5J����5c]��SbVU�`W��1b��z��w�kAN�a�_�Y߄��Z�$-4�:kD��D��U�;�|�;�W���:�D���?�ɂ��y$�'L ����:�D|����t�H�	�q�cV^g���$j�@��"���\�x�Q"F{�s@'<�q�3��Ҟpgݴv�惓(���׆=H��=��x��Ņ�*�d���7�H<8͇�1�3B�J82�7_�~��7�n� ���}/�4˸"��7O��=W�'���Q�X�|9\���t�s�v�o��Z�O|��^��v���y�<������<O��=�*t��,��$~f�:3)J�⡎<��A�G��ͫ��y��޷�X�����5�c��=.�[�����~������1c�٭S@:���y��w>���C�wE ;����?�o3XΧ(��Q�Q�����?���;5��ͧl�a@�Oe�W��<�"�O�+R��L���|^D!|pM/Q�y��h>;U����|���&��^X�� �K;��Aj>GD���s J�ݔ6������}ֹ|򳏈����<Q��\Ӛ\$2��4��Ad���{��t�<��ָ4ykj{9�1O<������a��^π�<����9�zS���<���eF_F��>���g{[G��<��S���~���C~��>��8��*57���\�Z{�'��h-A^���~�>�w	/��~@E�w��D]?�*'G�z"�_���t}2΃�|e/y�t�i��<����^�O�剿V���`.O���ڴ���3��D]?�|)���Y�z�#z���!��~`/O�5+��8���s%���}Fy�{ʖl���<�ڏ2a���y��r��ȷ��	h�m?��ql*`P�'J��g�6C����~Ԯ��`=�Y����Dh=��KM�YM�3�H7`�$�E5�g��(� $�d���V�,�YE���@P�gƶ9Ip�(~:G��Cx�g�$\lR��h��4��f" �!���oA��ڟ�0w�����Xk���`��43!oF;1Z(��Fi&��8���7�ڂ�U�^T1T�����y��?͒��6;N k�e�0ٿ;�XY��;�l�ՍNz(V	�]����1� l~��g�Cm���-xv�/��7
^Sּh���g�O��I �����?��8-xv���|d��тgg��>��h-xv�rϫ bDl���ڋ�k �@�F�9�Ns��ҞR�ĹZ�3���j��O����!��^�/�Կ �)�6h�Q�S����Iⴧܾ�
KS��͞���{���i�Mд?���ܺ������@B��2S7W�A� ����.|W�"r�c2 � �
�}�������%�Gf�*D��zKz!j�$9��}ڟ@U �z�c��9U �z���.<�xGT�T����B�p�����i~K=���)�E�珩� �@����d��(|޿��~B�}j[� t
�N?Ir���@�@��R�jL3M����w ��J�H�ԕ�
��~Ҭe�g�� O��i��R?!��O*@T ��	ӭ� N��I�<��?p
�r�L�"�)�pg��8<����Ul ���QJg�4�_���|�#�q�\�����\쇾FY��F�p?׮�Ͼn ����-�������x�4    c�@q6n�Q�+����� \��kb�HH@�PP��j�"�#�q[��Bɓj\��Q���/��R�f��8�,m�iRk��_�.Vu2��gu��C+@`W�~D�6�� �P�j�7o ,�F�4m�*<��ՙI��5k�Cv z�Z4v=竅����~�Ám����6�ӗ��;bHr�D���`�}x�S��3�=P*46��-,@*�(���0Z�� *46�f��Lll�)O��k���1�u������Mܫר&�/��������_�!�����:D�׻k� �	�1��P�K�Q�q�Jqa�N�w~2_��<v ).E�G3Hq��1_S]EPQ\ZW�s�Q����O:]������&67�]����ݯl�̋ �袑 Cѥ��a�S� Pt�G��T,t��B�������J�D�f��3q�w=2�٢�u&l&����Ǖj`�g3���~5���?�
�}��W�5���}͑Ԡ}�	0'�"�������?�ZPЉ���|K���(x.\��׊f���'��� ��F'O�#A��C	�C��5W��#�'�Jw+i>�W�O���֌�
=~b����p������~F�V��XO� �/��<�����*��
��iԕR�u��4D]-��e�';ԤDs7�z*���A���OI	��3�F]C�jNn���Y5�s���b���]uMU�=N� �������NHŴ���Z�� ��ʞIR�p��4I�k�o���RW@�+�[�4��CyG猔�teZڧ�%��)�R�
dSQ͹Y~���jt�~������K�o�{IE&)���ȫ){�Td�����w2U>=���\�����h?p�;-b���Ȕe��Y��Ywlj�Td�2�=9 ,��&�!���LU�Z�ra�2�=����ۣ�:�Uٔ�5�<�x*��Q^e./���7n��b��_j�Y�ˬ'��-#X-�����Ǣk<�V��Ξ��W���#.[n���b����Î��X�[�׺|R�\�W���.V5���P�V4 �XQD��hΡjP0U
�:$�� v����>�u��NW����.2ڭq�5�E��.��PmͿ���x���,��"��{��2(@t���V�3�T��8;�=J��� ��d�SF�s��Lu\�'رAKT��ht�+�CZ5�
x��奬��(�lp�z�fAx���2�K��r�6E7/Q��ȋ�N�W'����T1�IL`��x��D]�O`��h��ci�5v��C����%��!�����KK6
��@{i'oz�k�.>s�	����x��g�&^b£��\\����Rnv�1�鷂�1޳ݭU�	|���8������8U|#�{&�f58�.�=㙦��k�]"�#���O �D��L���*��ݳ��u����Kw�8�;�T= �P�$�{�����%}m;�$�{��=�y�L����Y6񃹂��	�|�G���d�&� E�rz���g�H�ڿ&��ѽ��
L�v�����X&�`�l9'V�e������~�y4�c���)8�N�
	���h��R�m��S���Qb����Z����T�$����K!K�s�e
�{��K����n_��#��EL����A�%B�g���L%ē�Y���<  �D��L3�쪻�Kx�8�~�K�t_�B�����C�(�~�-E�%�g맏���S�g7�Ƞx/`\"��(�`���Y��s]	�b���O�Fb�˫��_��0�~Fg��I�)�����0�$v�	kҭ1�~��.W:J���	��3�[c��,)v�(�&�i=n�+I�Q�+�����[e������_��'�Fp["n!'�Q/
�[�N4��Q�04{�2�}n+�vK9t=���׺'�%�[ʰ�b'��h#^K9i�j�d݅V_bi椁�Y���`n�g)�[
�|�,�H@���~�?e �T�p2
3}�,�Raˏl�?�Ra�Ox��jDao	=�l���zoz�Z�D��kX�$�(7��� �T�D?��EU�/E�2$�͙N��T�(?�N�/���$z��Tm)�M�.=N�.�@�T�D/%�b;�@J�z�}����@K���7�CH)Uv��'���I�&�Q��KpR�Y��|�VJ��Fr�GZ����:�n�}u*>�����aom��zL�$�Sjl��ƕ M���QXڼDp�i�E�)�pK11�R��T�>�O�����Ml���mbXH��6ˋ�p\<mU�����t�����5h�[�"�O<ƋOf�S^�D/�Eټ��v�
�b6[a��%@C#��3@*/Q���  �����ёȀ�L�3FQ>�WS�.He)�ƴWLe�����g�s�D/�� 7	�~F��Dv��y�vG�
'�2A���D�U�2���E�UU=
��~� �I �	��3�ɸ�G}=�:�w�3�*W=g���yYe"��=���^0l$�z.�&U=�Ԟ�N��L<�
.�^/e�T&���W<F3՞���Y^T<�;q�J,���<�O��I4k�/<v>��$�}�P������*x��@�d�Y/�r_�xT;�=�z�������6E�e�ٰ��I>�/JT��4[E��Eq��zz9ݠ,��b�}3X*vV�-�1���!!�M��`��*�AZ�>�@��(0�b�Ĕ��y���To���Um�3H*�eR�9�4��3*ڴbS���rw� 3X*G���^c.Gy��*7�6p�j����1��L�:����"��lj��@���=�g��T��^9֍p��8�c��7�ddPYNK���"�rrᴓE���E�����-��W�6��r��S�;�tþ�YJ&�[�1��Ar9q�\�3��\�3�@�S����ޟC0]NMEW;�~���f�1/�g��NY�E���.�h��׬$f?�}e�u����X�?��(����D`�n�n���P��j���t�<�6��Y�S�e֙�|��(�\��b�1�V��Y핎�X%ʦ���FjV�s�ùG}D �
s�Vq��˔"�A���R�7,�A���Y7�>�a.�*��]���3H1�Q2S3[���\�r�қ;n �\�U�K{���Q��ޞ����\Gip_�z^�A����x�#в�ٻY�r�~RK�����)s5��hN�U%J�j�Ȕ�<bZ%4sM��-R3�Ɛru抲9��"J��Tηq�~T����P^�*����{��'�|�9��������9w�� 03�s�V�ZAcp���9's�^-�2R>Ǧ!��X�*a&a�s~ʎw&�#(3%�I�v��(HLf���zuv8�	'_�.,��u�������q�B���m� &��풮�,�{�غ��Q�_i�8��=en�h:B�[�ў@dY���oѿ  ���Ѽ��
0�,� �~eN���
+�5
?�izl��F�N"�yvm��dq����p�8��k�q��B8���t\�d!�|�7wZ�[�������w���%L�0 "A�����#||1Yx,�/�$h2B��+���h,�/$M��B��PXT(��B�h�v6� ��VC��Y�Y��ų����3���b�yR�q�P,���[� b��
 b���Cz�4�_�f��p����-(��B8�Q��.A7c�sI ۼm��B���s��@��a)��K�o��L�ėE���_rK(=�ygPb!J�}�v)"ŗcͥ��0b�K����i�-|X���>�x�X�f��X����h,1Hl�S��|����/d�G���l� U�c����~��lrn�E����l,�Z妳z�E:uQ�S(����ϛ�dI�P<2�	��$��C��G/��M��V�Ē�0Na���.`�(�]���\�nJ��As�g<y�ήB,`Ò�L�92V�	K*��U�Xۼ^���_I����a镼�����+٩��f���]�^Tg�DO�p2D�
,Wr����`Nwt�g��}�us��5��\�n%�y�v:I���J��ѵ�'_�� D  ���* ���V�/���;WX�S~q��-	��_��5F����a/[w�/b/�ŵ�`n����~����<�K�pi
W��'{���͠S���ќ��ՠ���`/1�;w�t�|®�(�*�F�۪�����W!����ډ���
�K.*IG��R�[�xKt缃��a:���<�{�*�Y�x�]?�#�*���7u�@W���C�[��VP%No�G����6�[X�
��Q<#4TU��أ9!���J�������J�Mu:�������<�0�kl�c�fl;� �B`�J��0����
��g0�����yfp~���Dճ�M/��k�#x7o�S]�����}���*!׫Q�U	�^��&#��*��+;�SY� �W�S������I�����(�Cx�h�q��R5�W�o}w^եMZ��=�H���Juz>���6{<�^�[7����J��
a=�$�zeӱ*�b!2o�P�X��MNONWU�*��� �JdEѩQ���Jt��֣��"�z��f𢂮*��k�B\��%��`�]�5���4޷'� �JD�=����*����m����*��k���
��DQ�y����v����
��W��x�Z���W���T@V%�B|z$Y58��lb�ʹqz,��(����A,��r�IL����B�[n�]GՐ��Fae`+?��������ݘ�UC3�Q�VpT�ˈ��-�T�NT�s�F/Q,簕u8�ȾJf�V�Q��� ���f�z7՘T�#����W@T�y��f'���Xf��ɍ
n������7��ۤ���T�b�&P��!nc(��%v�Y	���j�����,�&�/KH����!�~!��wp��_ RMyh��6k�T<�����80	�T�x˯��;,:��*Щ�����h��j^F��y�5zR�O5;�RO̜�Q�N5{U{@N5�]+����2�৚��S�L�z�S�؅�V悿�6� ��[f��=�H�!�TsS��H~���Z�Piz�'a�jq]c\,��G����s��'��������1��+Щ�(Q��lpg@����i���T;|~�/|ѣ��k��T	@�Z�P��P���W�SU���ĹF6���ƪ�L.W��8�a���'ҧ0�=�����AezYM�1�UU�!�Yb�L�f�UO"�eh6���EVUs)���1Y�$�0����ʎ�C���E4��iyv����js]k�C�Tm���]�x��hl���CCOz������~��)@UmY5�sj*���2+�� {M���I)���H�����f��iz��=����-l-/:����n@��x#��_�k�F�ՖЅ�kp������ٜH!N��OE��e���5Z#U�J�z�W���Ќv_��k9%j�g�����vc��j�X���ȋ/k
��4����@>���!�{C��!�S�9B����Ư��߫�B����;2���M��,y�5�Ex��b���p�whj`����)SZ� ��j���L�`�5נ�c$G��@}͋��%��ט�x���h4���;8rx�ȯ1��8b��ט�0�d�xi����ǜ|l����sߕ�n��Է�d�Ǉ�&�c���c�x�c�t�5����t�j��T�} � ~�[&m�='R<�q#��~�Uq��wG*�y�{�*tʯm �Ƥ�'�r��Y���{�y�Ǽ��8�&2�Q��3�No �Ƅ��=�8��#�kDyo0<���5b;���;�k�|׈��0<�O�F�:�� �cԣ6�D�%�B�p�x���� �5·7;وo���F���E4�Y#8�<c�CE0�ȌEv!p��$vm��X�%�LN8�N��? ���2a9-P�XKl�	��G���Z��Ǽ���ZJ��m�|lఖ2��ۯ�%�{;h�*�ÛoFNs�Įq��z��>N��2{w*s"��l��4�=���2;']��-r�D!gZ�߀9J���;9���j9�BƲzTOx�%��G��rA�^��Ubf9l^���I����$\+�Fe���4�U+N��L-�jE�M�{
SB5B�7���z.�f�gP�J�٦�5 T#�z�m�{ف��; �D�Y�x�}ߊ��[$*�o�.t>5§7���F����%XjKH4�1�R#Pzs;�����9l��7`R���W��W"j���
N���x�U���_��>��Y4��DԈ��JR�TT=G�R\����(���W�3�	~��7���M�b&�y�������$f����c����/�������w�:o��n��
`q�����M�`&�y���#��pd�~K���ْ��~�r��G�,h���p�Z
�5���R\�N��l�Ѥ�jȺ�[��ӗ	^(~a��g�G���`��TgZ�q�K?�� �|���0fb:��ޖ���~�R��|Я�t���Ֆ~:�R�ԜNЅz8�Ҍ�o��eZ n���[��J����Q�*�*���j����̋�2��D�}��?�w�'1/�m�}I��q��ü86�/��?hd5�/|����E�_^>��F�Ȃ{�t
����%US'���8�Ǟ����z�s榲��*<+t�d�P�A�2�N	�T����$1m3I(��$*Z��q�]
�*����u�����O��ͼ���{��]h)���������,��~gv#U
AC�����j�=z6�B���N��Q5����e��=�y!n����?i,����jm`k�ngC!լ��g�l�U(��"��h5�&a�qJ��X*1FLH����_w���GD	]~����E�j^cHw�]VD!�x�P���#�T���N��m7�������2������ί��饥6/8�b9��t-�3A/.�T�m���3/<�
K���PES1�|z��G5/i�k}��Nk^��:�cW��ɫ�lN���j�k>���?�����~����$Qm�hm��ª�]���]�{*C�H��R�����.z����}S��*/�2M��üdv�Lq�5�Y��ү�1���1/9H��8K�h��&��{�'1/�J��(���:�R%^�lv_��*�(���q
������z��B����7��>A����5��./�O�q"�=`{��b(�?�c=ey!���}�I�+�G�'R��p=cy!z�Sߛ&X�Y^J���i�S��RDq���L϶�����k�q��bi����ceO��޽�3���N��7����s�ITK��w�#(����ӑ�O�x����J��W^:29��,/�W?��PG��T1=Sz��B��W��������_�u^DD��oX��W1��g./D[�v��ٵ�)�׬�/�ו�-���PR�v�s�b���]}�B=&��kQ�	�����a����qc��F�D.1DǏ���r�c��!ǘ�fa8�D�� �7�BU���]rz�i�sLRM�L�I�'�ʃ��&�)�9b��3N�_PE"Ń�������Z��h�h������+��ͣ�������P���Pc��~�J��d�5����6����q/qijNz\$����n5:���~��l:!�Y��{�#)�����?j��\��i�g�3�������?�?���$      �   4  x�m��n7���St�.9��+Ǎ��/�S�)��]�H]F�Ub'�&h�Z�EsA�-��n�r^��F=$�I6`�X��x�������y�@N�<������;<�g�8y��dWɏ�p��@^��n��V���f�޸V���A�C�|�8��?��P��3���Z���mT���k;�*"Kɷ r�<ҕ5��ɏ� ަ ���䡦�@��-E������@G���p����`��.E�n57xh@�ą�S��g�Z�/?"�t� w/ D3wJ�n�M���|-�,����� ��\``��f<��]7 ^
�!���O���Y+t.O�'������>d���c��,��'tyV;�N�X���v�M�����`)S�=�'Ќ���)��^�d�_�P{?�����ѩט[��x���|+��)wu7XFA�/���1�P;��^u��R����T��Q��@=����q�Jw�f����F�V���a�6��?,\T�}����(ɗp��L�GZ�}p�Fy�!�G��RU��pu��Z��M���c֡�U�\�7�:4H9�HpbH�y�	O�Dk�|M�~{�Q�1k#�:��OpM�a�A�__��Ίa)�����������	��@��!���ZH�Q�<XC��asc���>V楨�]���� �I���w����:�@����&�&�v��V�Kd�0�(r��؂�����	�$De�X�@'����"�)�d��e�f*�+��XԣB���((o�#�Շx�*�lm���qJ O_C���E^(�$O�������^��qGMZ���\~(y��}!>ŌbJP�ޮ��)qռ(S���v|un�8��N���h���IX�z+b���]�
l�`�g��M���
���w�ֆa��J<�=���Go55O��t��W�a��K�p~�p�et�#�Mv�iQn�o|{㮩n�@�>��?���f̒���k��è�Sv��yq����Wj�˃Y�f����V�Զ9J|s�#�k5��♦P]ؗg�6�q��Q��5V���B���J�c���߭���ǆ)�����b��jfWo�l���{�x�Z��T[���`�*� ����` l��R ]�jK�c����4L���od�[~�R��|�]�4�����+,~pLwk�i�@�f*�%:L�m�Ǧ-o�������ԯ�����j�k�q��R��{[۷ni�f+X
|�w���g:]�t����2����ذ�{�N\����2�J�g�����j�u�a���kKKK���u4      �      x��Z�rU���z���TŔu�.-�K��dRsӖ7VcImZ��w�r ��a��~r ��\0$NL���*x��I�����`jn�����:�o�~>|4�`�p�t8}ff6�[��53%�qL��M���]]]�@qa��m�L��I�CD���t"C���>�?�LφO�������b��{�횙�2]2�%�@�G:]{��r���,�S�/�x�,ך���T"ϯ���`��������p����χf��QM���ݎ���2:�(p���1��nr��V�ۀ,��M'�1��xH�����=�I$�������*%Ħ��
d:�L
dt}����= ���4�ؘ�ySvl*���G7����׻������h������tJn�nb�Y��HRA ?�G�qH�e1��H>�HfxH��>�X}��l2��
�>�9�|� ��D�����Tw�xB����T��S��b�$�C�p��)�-���LIT��� Jr�9�G��j����2%g"*�X�;]3����c>��l*��V������d�z]SZ�%�T��}.�3b�7Mɶ� �<o�B`a�T���wŚ��_!�H�����4#�-/�Ҝ�$�HerDU�s�{8���	��z�v)t�ђh��B�{,ǖU���KO(-�� ��a��Ag��-�z,�#}�/�/��zɗ��@��M�o{�<�����M��nہN��׻�;�$���,�}Fa�U�{��=�{t}j��Zm���]��Y��u��\�ɽ�'f]waj�7���D�بZ�N�%ņC���"K/�=ذL�h�+v˿D�/�p��t"=�S]�d{bp��]v��Χiچ§*� !�mJ�@yDbj�xbs���~8V�9�=��k	�I�ԡ��q ncx}��r��������φ�g?�5K"�N��P�m{j��؂�I膏a��k=g���s�.,r��O��H�65|��Q�a�q9�n�7%q�B6�Hg��&�@`�m�Ғ�_!��)F�@���K�r������M`tì����f]2K�.COy��b؅��E�>�c�>�v�	��L�x�)}�;|!a�@�Y�]{%����9k*����	��h�}�8Jw�����Y��-��,��0��Y'R�Y-b���q�{����n��7�o��%��,��x�>�q$
_�l�5����g�ɗ�pO��n�]� ~�����~�Af��v͢�+�����g��,��t���5{��1=U��v6�$j��h��dtK/j�����i�G4�1|!k Է�pǚ����H1�ҭ���7�}ہY��2�lvZ�1�(���d��)��f@��1*v���WB� a �!)�qFV�4�� �vw��5�Ȧc�:�l6���Y�X爴��R]i1`��W(̂h6;Ɋ�P����1͢����E=��l.�=���	�r���,.+
��$��!��v]��ɧi8n�p�9�S>�s�vi}f��X�W��L&�	uiQ�,�� 4�4�;�r*,$���( ��;fA��X��j,�Y������]�d��i~�E�+�|���9�`Xm.� ������ކ´g5���sY�}�4����JlV������WA%���ڝp��5ͬ��L"U�]|����m���͜ZH���1�Pա.V�B�E�M�6�Ƒ���\��>ɳ� �w�C,�i���{�W�Ά�qٚ��� �<4���X�T�f���m�T���|��Y[�De��&Q�����cIMOc�ߵ="��P��3D29>���l"e�;�}@P�ײ��f)p�3Ko��B"��?!b~MH��s�`��Y���9V��jfI�y*�׉'a)��Ks*�`Ƌ�Q�UWq UTԋ��;�@��Zed�i"�������F�אV�N������4o[���m��B>Q�2���>Ť(��7ew�:�6ش��.�&PH+����q���^q�[R�/kGV,$
�J��sv6|*{yQc4O���uA6�d�Um�p�����Sv%��g 	���7]��7�k.��~���e�����>�ȯ�'�,��n/kݎ"�8-�t����l�^���e��D1t��^�m�5�QX�|)�Qp�L�Ţ�,����E�,�X�"��>Fj]�w ��2�)�M�缾l�St��ĩޔ�ڞb֌�������%0��O�ȴŬ������ZV5�3�bN���;�XS��!_H�_�N_���0�}X���xӟ��Ly֙��@p���׻�lQ�?	�.�V�%��K�-��X�����g�e?���k��i��zN0���55�xz2i|i{�W�lІNO��KS�!���Ye.)��єO'|�>y�oO�`��߷��kK�|tB����OZ��5�e���5�l4��i�����d9����,_нq4g��V0X���o?�P{Կ�����|˯�0*�"�W��Tftv&'�U�IV�>zES�`�!1�'�"=fd*���[��h���R d�= n��RR OY�q�$��\����?|%�ҡ��A�7T����L�n8�܎ۂ?#tT$:dX��m���?#�REU�&q��uaS>��$*�m�������^Y�!89	�o%L��+^�
�UQv,�Y��oG�¾���?�2ﱩ����a�e*k��H����"��0U7dw�xWU`��f'���\
�MT�hy�3��'J�D�
�������U��\H�ܒn��3�n����y��Q$PAA���n�V�d�����܊�S���{�3U�Z4�Ir61�Y���e�PU�e�w7��Y0��'D�$��&xx��C,�ٓm�u9���#ş�Ь�����v�}��x��Z���M�Nf��T��8��~{1}�הQ+���݊(N�L�Clz�,ԩ.�"5�ʌq���'���Q�L��[6����T��M}F�2�4�"&PcT��(T���������X4����0��r���᪋z8N!&�/�-e��qKo��#v0��>Q&"?Y��a�EZ��MIy�@�ɳμݴR'�G|���N$�bMǬx4y����WXU��/��Ș&y ��6�JU���_�$�e��ҡGb�TA��qˊ�����5�%Y���`��L�fJ	$���~�8���u�P>	�[��1�!��pס�jʧ���ܖ���au/+���$W�H� � 4+�ʡr�?�K{`V��6+5��%��< ׌б�m���D�'	��ϺO���a�En#�RvC�+EC��R�%!p��U��$ǼX�V��%g&H��� ��e��<$?n���C��4�_����֕z~E����Ĩo���N<��-�����e����R�~p��5+�uW�1������t���O�OT�Z	��!Iys���33��<ݎ��w�b��T��#�����;qr\R]��^����MI�C��Sn�>���Yx�S��Kڷ򞀼�)�Hb����s������2���2���ů_�T�E��
�^�����巴zƱH˜�O푔>~)�k�z2A�?1��6���Q�6gɃo�c�bU	3n6sj5���$2�y�݅����QI�H��<��b��>�����Z���/gC�����Ҏ�Fl+�^v=��1�<���;"��������8�e���w �Y.����� ����h���Ye��8�OC���o{LU�D�Y�|��xv���J�aeOw�N���N�㚚ƺ"2/�'"^D.��ޑ�����k������\��a��.�!�-gJ�Y�ۻN�Z��u���k���jV:c�g�D <�[��l&B�$oYswB�a(�̚FK�2`w��'�z���]S��1?������Y�ڜ~����#Jx����y���P��c�;�{�d=`j��W���FL��|�y<&1j~���)jJ�3��ܺ�H,��q�.�Zh���~�7�U�����"�n:sQhj�=�4Z֙������-V~�=������$)1.�)����6�zhAVUR,�I�i��&K���M1�<-9%�A�#7vW��#�:V/C �  `�YU2�%0�1"�u�~G*�U�Nc�Oj���Zo�/ԕ���~>���?��1p]�� 姩��!(i�|_�}�wt�Ti�;����߱$j����XSW�13�#�xCK���1��n��I�J�Ȗ�7�LcR{b�y�F��_Լ�u�}&��{�gMv*��Ii'�@1A�}	+Q ���$���~��M�m�.�e��D%:38u#�X�̺��-��N um���<�=,�����c�?����6V1����Y�(�m��8�є^kK���s(��K��[��W�vvMI0����F��<��h��>�n�� H�Ϙ���\�JB�^���Z�m]� �}!�x�Ed2���
v�j�?�_�Y��9A �^: ���zY��'�N̎�8�2��6�6+�ټ��@�ۢ�=������V�%�V�-b���$w���N"-����c�<�u�*��6����ҵ v��\d�6���U~0�BQ�{�J�B>v�ٲm�5S׳��A�KhBM(��h �?�J��OCŤ9�P?�t�9�l����r<�ܢ؈��Ƣ��ߩ��h���@uI2�w-&t���*�6:�m���n�V̜�b.�8ylR_RRxQ�᥎[_)|%_���+���]��6��Y��Ld���WL�r3y�u7kcY��:�@IU��+:�:�X�������ςNp�u�y�{��zX�����>��D���=!���n]bt`� M�V��VL�N�tӦ��ѩX�˦�A����}q�_�O�{�]/*��T�|G�V� n�L��j�n�S��f�L˷�M徕-?���˼{�|�ѴB
+�޸�z�du�#�������M��v��RD�=ao���l'���@9�)%+�J��u�`�«4�P���Rd4��[��|�P��R��#�I�↿mY7�	�cQA�� ��MC�!���Gޏ�-���6�cI���aަ��H��p����x�ҕ��sc�]���66�m[�/�R���Z���H�5��@��� �i���06|��Q��@g"ttL��55�"NMR���k��-����֓��HD~�?"m4a�kW6ld�k�6>�"���D�}ֶ��˚���%���/�(I<�������۞f����
/�S����h��ZJ}�&��@S%U�@��E�2�ϻ�o��a^o�i|$0���f�{�3�z=�ჳ�~=���E�Xk-����H�ie2͍�|�6�/�=�����+Ԟ)���K�?�7\7&(�&_�������Ggr^��m>����ҧ�'(��^�F�1��z3/���B�$&��8IE��Ñ�zA#$H�u<E����w��@'7�q�>M/�k�D�l�U�T��Ѥ��֕z�Y�~�5^ܠz�PC�ɒ��gD��u�g��h\��7D�NS�+�S+���M��|������?��C��mg���+��l'ɔA���Sn���z+���2�W]Dڑ�di���w�E$(�D�[�b!����+#�`�'3�ujۚrES|����ׇ�W���^������ɇ,�t
8���e�gȦJ~�ty"�0|����X�?���c��R
Qs��-���U��Nsb��>a3?rOSrv��R�9����U�AB�?�>u�D�\3t7���I��X�H�'�@c��w���{�K#���NB᧘�H��4&Q� ,�������4Fp#)>�9%]�F����N�.����-Y֟�3�6����kN�=MP�D�?�}���tN��adW�/�T_(���������Iǌٱw�����E}�ɓV��C}y���c�_׆_����ՕW��6���+:����>���Ti8I؉�|'L��|�׳�-R�E3��3g�f��r���@��f���H����9�*��I����8���፾�C���7���+:8X      �   q   x����@E��?tC1B�+$a��
�����yy��ϹwX��>0��W,D�v��'��l���,�&�O��4�q���'>�Ua}����A�+�),�y��� �K�      �   -   x�3估�b�m/캰��N.#��.l��,�(���� ۊ      �   �  x�u��n�F�ף��2\1ΐ��I�E�dCI�$�"SJ��l�H	�$H�!E@�-��H}�����.hA"g(��9���ў�;�ۙ=%���n/�����Ύ�)�L���������I�L�$�cw0����N�n3�n��2I����Z�!� �Uh'`U�
E��z�~ ;�0���}خ	b_��7D�cbO�Ԟ��'@�ٯ���I�A���N�$�v?�Ɨ�2C���{�W�U���7���v)/
yI�g(D�g���E��P���c���?�g�/0��n6�D�Fen7�I��d�
>�8�)5e
�zO4F�o�����}���LГ�SD9�	X4�ׇ,�Z�0Y� *�T����@�h�h(<���O���^*{��"���+�{UV6@��p	홁#�E��?썆�N��W @�,��`
d�)����}�~c��AdP�.��@ra�&�U����6���q7i��(BFE�!�"9'�׎�E=��k�ֆ.ItA�c�ϰ����!������v�4�a+M�K��,Rh���v���ה{@��om�V%�_P(
��I1�clŤ4�}5����S��Ӎ[����N�^�"(�0 +��=�p�$`@P������-1������T�xS����������}7K�z#=��(	��)���Ό}һ��Z�a
 �� �POp<��|tbl�/�^KGU3�*��<�8^�k�S�1���� ]�d�[?n�.`+a��`V��pS�F����-M�`BǤw��5��<��'~�Y5�a��.�	�}���pS&{�?�⟢X��Y^�ca�zJ$I��A��_��	�*.x��@Qs�Ew�%R=pk��?㯚�      �   �  x��VMo�F=S�b�6 \Rԇ/�kՀ�`5��"�j�"�Ei��]���@/͡MZ�7_$K�e}P���?���\PX�Drw�͛7o)�QE�P]��>�B��.#}�BM�L�!~ޜ�k5�ou��n����f&��}�\
��������N�ৱu_]#�P�	zj�&�뭇[_��5���?������Xa��9�,���S�,�}H��(�TEj.�~��P݄+<�o����j�S��/��@WB]�H�ٵ�c}d�\���j����/�V��m7ܝv���7�/�T����P��ǆ���BW��
!��Q����&�R�Ms=�	Պ���%��P+r�~Q�c��%��j�[CZ����Rf�kNhXN�#�!����}��X�шv0�ȋn�2"1
���7�&����R���״�RU�9J* ܂���z�qF�1 Q�s�_��k,8k�_��'��W�J��~~����ʖ��i����S3yfVrs�>���>���m���	;ei�@ɉDO��M,E����y�l���l
��1o�|���>9֫N����Y��q��7���B��xpAc"�-�Y�DHj$�#�8�[�v���J�dy˅��]d�f@��-�Q��G��Hi�C�Bb}f8#��-�l� �"&I��8�5�:%0��x'L'՜+�,�w(�-� c)f��bq���VlN�	A������1Q;�_�n�� _0�jJ��W�T���벁�1qS�P��R�� !��-���<��`D|�i7��,)�
�3����|��	����9�l�YJ|PaP�ӧ����TJ��B�c��
��Όz�ֳ�����.uL��U=�3���ph�W�!���鑘�B��$�|B�A�7[Ueb���1��t\�O�,L����i�*��(Ć�t�#s��?�Q�Z�Ҷq6��+�9�Y�玬܍+Nj&�d�<����IoK&*6�*,h�O�Z}�^�f�)v�����ǝ��z"G����y(+	���������7������mm?iv��Y�d%0�j��fp����Ι1��V~����y�Q��'<�3���ΛK>K��rg�+��#kv2}�N���%�A���*����P4ƑX���]�|o�~�������>IKc��O��t"p��k$�\&�O�7-���{	qז��F�P�7o�      �   �  x�}�ّ� @�Q� ;:8S�V���XI8>`�O����(P`d�(���˯����gi���~�>R�#|��Y�Ѓ�@���/���7B�$}*%s\��
����@>By��P��@9Be�+e
T��S5})ѿ-~uDv���կi0y3�#�W��1��0��'��m�p+�HOs�
Dgκ�D�`��q|�x�$�`��檠el�-��#�D�5�܀ҙK[��k�+��\���C3�؞G%�^��fZ��^� ��nI�l��d��V��m3ׁ'G���7Z#�h�t��Վ�3ȸ�2N�n ]@Z{�i��\Q�38��|I�xuem�T	�\@Y]š�'��tm�P�� �mr2[�I���#�W��nI��d�r�ڱ�ݓ�`��u;[�n����l�*y*��m�~z�gA��oM+OXl%Ϥ�曞.����� ��	�      �   V  x���KoW�ד_�����D�~a
T%(��f|���$��񊤥 �[���*PU*�6$X���7��Q�s���	�T3vf�NΓ�{��;$H_�'���>��vң�0�����S����pq8څo��t�$��\�ҧ������Z��'���&��_tg�X���D�Za� �#_�]��6�A)i'f>�(�� �;�Zǣ�F��zA����!�����8}��B5�7�����BF(�%"� �*�W�P�3�K-c֮0C��aA�f�=�r��I������p��Θ�� a�zm�`��od9$FX j�� 6,TZ!͑P��4h�|O�KK|�qh����7��`��{�B=������y�;�$�7�s*΢��F�LQ�iL�0G#�ǲ�k���7�$ı�s�{���܅��ls�@u���Z��5��U�d��F� �2v1��uv<�LI���u���8��H�����@�7����l��ƞ9��SΙb��5���h��3<x�41j����`t���a�Gy>N�������aF�f�˭�����DF[��LŤ�(�EH�DR ͜�u|W,.҈6<wH*�:�A�ƶ��{�=;�̈�U6V�E��N;j$�h"uV��L��1�-8�p�7�(_�4��W!������"�5�Q�ɼ�ֈ^_H:�Z��O��b��4`��j��v�yź���e�a��!�v� }����z��v�$�Fckg�ɵX�Q�^�yFh �X�@\;$2pg�(g in��R��D=��uB��-��ȹ��;z"q����l����v�TzmQ�Gq�4�5T/���O4	��Z�������-���|6�@�1֟ ����艿=���77K�bÔ��6Sڵ�ʸȢpN���a5뢵�"�opڮ8ꃙ@2����9�C��5�l�Dڵ�e���Ժؒ5��ՙ�%�u5���FbJ�T$��!�����m�KC}*�����I�=E�n�9��Mŉ4V$�h]�O�J	P`��l.
%B©�L%P�2�"U�)x ��D�Q��9L�vj����+�pR�-ޞ�Ҋ����VF�*�8��ˢ�iV�%}��Q|$��çʜj�Wv����kS�uڲ���0�R؜�v!wi[�:��ƝK]!/�<�OC���s F���*����`�83N�-,�$���Rg�GڎBTf�v[p��f���4;���W�*�<���u2yl�	�Y��x�^�2.U�03��N��Iʬc4LRL%��b�ea�6��*��<�f��+lv> �`���y�~�c[3�?����Xv�7T.�j%Ͳ �ڍ,�T�/!p(!��-���Y��E}�<��'4��~TC(��$y^���a�q�N���q�����Es��FY6�gG<������)w��K�i��-�|B���:pcj��.�����-Y7��j�w�dav�ьFv�
�r�T8�+\^��"�{�Ğg�e��D�&���z�����5w�l��5��z���3�Tؑ��"/rq��yN���u�m3	h�����\�^�Z-B�Wp7G����(���u>�z�b�����/ݛ������@{      �     x�m��N1���St�Y�_��"�
JU�T���ɐ!7XAD/�J��UK��ЈH)�
�7�og�$�r���|>��C��e/m����;{c{Ȟ�A�֞ہ"�	ֻ�r{�������(!��|9]ܞ�Tˈm0����<�oD�z20.1#��hy�[e��Q�ڨҹR��h�!���
D���9��y|w�7#���#>�}x���݌�2���U���q&�h���0&n8�s�t~3|���3��0��R!�'�0g��S����C��%`9�X{#�&k���~�ژ�gBLؔ9h�3��Dl�u_��zD&�pd��R/ѹߛ3�<�O���ѻ���{�����fc�Z��h�S4d�u@ł���ʒ�,m�a��'�d�x��1�gp��	;�,]؛���.�v5S��j�f:�(L���i`$�Jb����달��D$ ٯ���F�����!�)n.*n�꙲�iy�*9�P(�p�%XkW�|d?}�
f�L�Q��pv��܌����V7^}�Ѩ�	�"��Uh�K�����RLɄE8G���"��D����j�%<�JX����������s0��.%X�b?�h��R'*�tM�����`��	@p��e嫅�ײ�C���,���Ϥ�C�:�]�qKQ!�,�J�n�1z�LWC����CG)��<Y�+�V��LR�-�ݝd��΍�c{q_7�m�e��T�Dw��2��a!"���fg�'\>ۈ�F6���f.�J��d<�      �   �   x����@D��*� H�� '�	H��Ё�t`>��#�HvG��O��]������H�h��������kڂIFχē�t��VB̤F?�W^{��v�[�"��59�&p�B�|u:��D�/�NT�Ĕ�2�{����~�jr�     